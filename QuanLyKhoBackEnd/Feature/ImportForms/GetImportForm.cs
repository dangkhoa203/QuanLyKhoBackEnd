using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.ImportForm {
    public class GetImportForm : IEndpoint {
        public record ReceiptDTO(string Id, string VendorName, DateTime DateOfOrder);
        public record DetailDTO(string ProductID, string ProductName, int Quantity);
        public record FormDTO(string Id, ReceiptDTO Receipt, ICollection<DetailDTO> Details, DateTime DateOfImport, DateTime DateCreated);
        public record Response(bool Success, FormDTO Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Import-Forms/{id}", Handler).WithTags("Import Forms");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Form = await context.ImportForms
                    .Include(form => form.Details)
                       .ThenInclude(detail => detail.ProductNav)
                    .Include(form => form.Receipt)
                       .ThenInclude(receipt => receipt.Vendor)
                    .Where(form => form.ServiceId == ServiceId)
                    .Where(form => !form.IsDeleted)
                    .Where(form => form.Id == id)
                    .FirstOrDefaultAsync();

                if (Form != null) {
                    var Receipt = new ReceiptDTO(
                        Form.Receipt.Id,
                        Form.Receipt.Vendor.Name,
                        Form.Receipt.DateOrder
                    );

                    var Details = Form.Details
                    .Select(
                        detail => new DetailDTO(
                        detail.ProductId,
                        detail.ProductNav.Name,
                        detail.Quantity
                        )
                    )
                    .ToList();

                    var data = new FormDTO(Form.Id, Receipt, Details, Form.ImportDate, Form.CreatedDate);
                    return Results.Ok(new Response(true, data, ""));
                }

                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
