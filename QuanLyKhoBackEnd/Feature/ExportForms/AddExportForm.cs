using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity;
using QuanLyKhoBackEnd.Model.Enum;
using QuanLyKhoBackEnd.Model.Form;

namespace QuanLyKhoBackEnd.Feature.ExportForms {
    public class AddExportForm : IEndpoint {
        public record DetailDTO(string ProductId, int Quantity);
        public record Request(string ReceiptId, DateTime DateOfExport, bool UpdateStock);
        public record Response(bool Success, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Export-Forms", Handler).WithTags("Export Forms");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {


                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                var Receipt = await context.CustomerBuyReceipts.Include(receipt => receipt.Details).FirstOrDefaultAsync(receipt => receipt.Id == request.ReceiptId);
                if (Receipt == null)
                    return Results.BadRequest(new Response(false, "không tìm thấy hóa đơn!"));
                if(DateTime.Compare(Receipt.DateOrder,request.DateOfExport)<0)
                    return Results.BadRequest(new Response(false, "Lỗi thông tin!"));

                var Details = new List<ExportFormDetail>();
                foreach (var FormDetail in Receipt.Details) {
                    var Product = await context.Products.FindAsync(FormDetail.ProductId);

                    if (Product == null )
                        return Results.BadRequest(new Response(false, "không tìm thấy dữ liệu!"));

                    if (request.UpdateStock) {
                        var StockCount = await context.Stocks
                            .Where(s => s.ProductId == FormDetail.ProductId)
                            .Select(s => s.Quantity)
                            .FirstOrDefaultAsync();
                        if (StockCount == null || FormDetail.Quantity > StockCount)
                            return Results.BadRequest(new Response(false, "Không đủ số lượng để xuất kho!"));
                    }

                    Details.Add(new ExportFormDetail() {
                        ProductNav = Product,
                        Quantity = FormDetail.Quantity,
                    });
                }

              

                var ExportForm = new ExportForm() {
                    ReceiptId = request.ReceiptId,
                    ExportDate = request.DateOfExport,
                    Details = Details,
                    ServiceId = ServiceId,
                };
                await context.ExportForms.AddAsync(ExportForm);

                if (request.UpdateStock)
                    await ExportStock(Details, context, ServiceId);

                if (await context.SaveChangesAsync() > 0) {
                    return Results.Ok(new Response(true, ""));
                }
                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!"));
            }
            catch (Exception)
            {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }
        }
        private static async Task ExportStock(List<ExportFormDetail> Details, ApplicationDbContext context, string ServiceId) {
            foreach (var FormDetail in Details) {
                var stock = await context.Stocks.FirstOrDefaultAsync(s => s.ProductId == FormDetail.ProductId);
                stock.Quantity -= FormDetail.Quantity;
            }
        }
    }
}
