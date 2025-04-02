using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.VendorReplenishReceipts {
    public class GetVendorReceipt : IEndpoint {
        public record VendorDTO(string Id, string Name, string Email, string Address, string PhoneNumber, string GroupName);
       
        public record DetailDTO(string ProductID, string ProductName, float Price, int Quantity, float TotalPrice);
        public record ReceiptDTO(VendorDTO Vendor, ICollection<DetailDTO> Details,string Id, DateTime DateOfOrder, DateTime DateCreated);
        public record Response(bool Success, ReceiptDTO? data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Vendor-Receipts/{id}", Handler).WithTags("Vendor Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Receipt = await context.VendorReplenishReceipts
                    .Include(receipt => receipt.Details)
                        .ThenInclude(detail => detail.ProductNav)
                    .Include(receipt => receipt.Vendor)
                        .ThenInclude(c => c.VendorGroup)
                    .Where(u => u.ServiceId == ServiceId)
                    .Where(receipt => !receipt.IsDeleted)
                    .FirstOrDefaultAsync(receipt => receipt.Id == id);

                if (Receipt != null) {
                    var Vendor = new VendorDTO(
                        Receipt.Vendor.Id,
                        Receipt.Vendor.Name,
                        Receipt.Vendor.Email,
                        Receipt.Vendor.Address,
                        Receipt.Vendor.PhoneNumber,
                        Receipt.Vendor.VendorGroup != null ? Receipt.Vendor.VendorGroup.Name : null
                    );

                    var Details = Receipt.Details
                    .Select(
                        detail => new DetailDTO(
                            detail.ProductId,
                            detail.ProductNav.Name,
                            detail.PriceOfOne,
                            detail.Quantity,
                            detail.TotalPrice
                        )
                    )
                    .ToList();
                    var Data = new ReceiptDTO(Vendor, Details,Receipt.Id, Receipt.DateOrder, Receipt.CreatedDate);
                    return Results.Ok(new Response(true, Data, ""));
                }

                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
