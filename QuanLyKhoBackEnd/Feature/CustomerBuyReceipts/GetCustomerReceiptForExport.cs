using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;

namespace StoreQuanLyKhoBackEnd.Feature.CustomerBuyReceipts {
    public class GetCustomerReceiptForExport:IEndpoint {
        public record receiptDTO(string id, DateTime dateOfOrder);
        public record Response(bool Success, List<receiptDTO> data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Customer-Receipts/form", Handler).WithTags("Customer Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                    .Include(u => u.ServiceRegistered)
                    .Where(u => u.UserName == User.Identity.Name)
                    .Select(u => u.ServiceId)
                    .FirstOrDefaultAsync();

                var Receipts = await context.CustomerBuyReceipts
                    .Include(receipt => receipt.StockExportReport)
                    .Where(receipt => receipt.ServiceId == ServiceId)
                    .Where(receipt => receipt.StockExportReport.Where(form => !form.IsDeleted).Count() == 0)
                    .OrderByDescending(receipt => receipt.CreatedDate)
                    .Select(receipt => new receiptDTO(
                        receipt.Id,
                        receipt.DateOrder
                    ))
                    .ToListAsync();
                return Results.Ok(new Response(true, Receipts, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
