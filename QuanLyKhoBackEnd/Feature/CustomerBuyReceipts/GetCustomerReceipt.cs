using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.CustomerBuyReceipts {
    public class GetCustomerReceipt : IEndpoint {
        public record CustomerDTO(string Id, string Name, string Email, string Address, string PhoneNumber, string GroupName);
      
        public record DetailDTO(string ProductID, string ProductName, float Price, int Quantity, float TotalPrice);
        public record ReceiptDTO(CustomerDTO Customer, ICollection<DetailDTO> Details, string Id,DateTime DateOfOrder, DateTime DateCreated);
        public record Response(bool Success, ReceiptDTO? Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Customer-Receipts/{id}", Handler).WithTags("Customer Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                                .Include(u => u.ServiceRegistered)
                                .Where(u => u.UserName == User.Identity.Name)
                                .Select(u => u.ServiceId)
                                .FirstOrDefaultAsync();

                var Receipt = await context.CustomerBuyReceipts
                    .Include(receipt => receipt.Details)
                       .ThenInclude(detail => detail.ProductNav)
                    .Include(receipt => receipt.Customer)
                       .ThenInclude(c => c.CustomerGroup)
                    .Where(receipt => receipt.ServiceId == ServiceId)
                    .Where(receipt => !receipt.IsDeleted)
                    .FirstOrDefaultAsync(receipt => receipt.Id == id);

                if (Receipt == null) {
                    return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
                }

                var Customer = new CustomerDTO(
                        Receipt.Customer.Id,
                        Receipt.Customer.Name,
                        Receipt.Customer.Email,
                        Receipt.Customer.Address,
                        Receipt.Customer.PhoneNumber,
                        Receipt.Customer.CustomerGroup == null ? null:Receipt.Customer.CustomerGroup.Name
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
                ).ToList();
                var Data = new ReceiptDTO(Customer, Details,Receipt.Id, Receipt.DateOrder, Receipt.CreatedDate);
                return Results.Ok(new Response(true, Data, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
