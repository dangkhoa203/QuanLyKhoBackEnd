using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;
using QuanLyKhoBackEnd.Model.Receipt;

namespace QuanLyKhoBackEnd.Feature.VendorReplenishReceipts {
    public class AddVendorReceipt:IEndpoint {
        public record DetailDTO(string ProductId, int Quantity);
        public record Request(string VendorId, DateTime dateOfOrder, List<DetailDTO> Details);
        public record Response(bool Success, string ErrorMessage);
        
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Vendor-Receipts", Handler).WithTags("Vendor Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
              

                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                var Details = new List<VendorReplenishReceiptDetail>();
                foreach (var re in request.Details) {
                    var NewDetail = new VendorReplenishReceiptDetail();
                    NewDetail.ProductNav = await context.Products.FindAsync(re.ProductId);
                    NewDetail.Quantity = re.Quantity;
                    NewDetail.PriceOfOne = NewDetail.ProductNav.PricePerUnit;
                    NewDetail.TotalPrice = NewDetail.PriceOfOne * NewDetail.Quantity;
                    Details.Add(NewDetail);
                }

                var Receipt = new VendorReplenishReceipt() {
                    Vendor = await context.Vendors.FindAsync(request.VendorId),
                    DateOrder = request.dateOfOrder,
                    ReceiptValue = Details.Sum(d => d.TotalPrice),
                    Details = Details,
                    ServiceId = ServiceId,
                };
                await context.VendorReplenishReceipts.AddAsync(Receipt);
                if (await context.SaveChangesAsync() > 0) {
                    return Results.Ok(new Response(true, ""));
                }

                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!"));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }
        }
    }
}
