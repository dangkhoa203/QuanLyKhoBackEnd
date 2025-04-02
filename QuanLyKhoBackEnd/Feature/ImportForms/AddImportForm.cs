using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;
using QuanLyKhoBackEnd.Model.Enum;
using QuanLyKhoBackEnd.Model.Form;
using QuanLyKhoBackEnd.Model.Receipt;

namespace QuanLyKhoBackEnd.Feature.ImportForm {
    public class AddImportForm : IEndpoint {
        public record DetailDTO(string ProductId, int Quantity);
        public record Request(string ReceiptId, DateTime DateOfImport,bool UpdateStock);
        public record Response(bool Success, string ErrorMessage);
    
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Import-Forms", Handler).WithTags("Import Forms");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
              

                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                var Receipt = await context.VendorReplenishReceipts.Include(receipt => receipt.Details).FirstOrDefaultAsync(receipt => receipt.Id == request.ReceiptId);
                if (Receipt == null)
                    return Results.BadRequest(new Response(false, "không tìm thấy hóa đơn!"));
                if (DateTime.Compare(Receipt.DateOrder, request.DateOfImport) < 0)
                    return Results.BadRequest(new Response(false, "Lỗi thông tin!"));

                var Details = new List<ImportFormDetail>();
                foreach (var FormDetail in Receipt.Details) {
                    var Product = await context.Products.FindAsync(FormDetail.ProductId);
                    if (Product == null )
                        return Results.BadRequest(new Response(false, "không tìm thấy dữ liệu!"));
                    Details.Add(new ImportFormDetail() {
                        ProductNav = Product,
                        Quantity = FormDetail.Quantity,
                    });
                }


                var form = new Model.Form.ImportForm() {
                    ReceiptId = request.ReceiptId,
                    ImportDate = request.DateOfImport,
                    Details = Details,
                    ServiceId = ServiceId,
                };
                await context.ImportForms.AddAsync(form);

                if (request.UpdateStock)
                    await importStock(Details, context, ServiceId);

                if (await context.SaveChangesAsync() > 0) {
                    return Results.Ok(new Response(true, ""));
                }

                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!"));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }
        }
        private static async Task importStock(List<ImportFormDetail> Details, ApplicationDbContext context, string ServiceId) {
            foreach (var FormDetail in Details) {
                var stock = await context.Stocks.FirstOrDefaultAsync(s => s.ProductId == FormDetail.ProductId);
                if (stock != null) {
                    stock.Quantity += FormDetail.Quantity;
                }
                else {
                    var newstock = new Stock() {
                        ProductId = FormDetail.ProductId,
                        Quantity = FormDetail.Quantity,
                        ServiceId = ServiceId,
                    };
                    await context.Stocks.AddAsync(newstock);
                }
            }
        }
    }
}
