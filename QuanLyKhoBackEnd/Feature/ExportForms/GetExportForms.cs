using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.ExportForms {
    public class GetExportForms : IEndpoint {
        public record ReceiptDTO(string Id, string CustomerName, DateTime DateOfOrder);
        public record FormDTO(string Id, ReceiptDTO Receipt, DateTime DateOfExport,DateTime dateCreated);
        public record Response(bool Success, List<FormDTO> Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Export-Forms", Handler).WithTags("Import Forms");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                    .Include(u => u.ServiceRegistered)
                    .Where(u => u.UserName == User.Identity.Name)
                    .Select(u => u.ServiceId)
                    .FirstOrDefaultAsync();

                var Forms = await context.ExportForms
                    .Include(form => form.Receipt)
                        .ThenInclude(receipt => receipt.Customer)
                    .Where(form => form.ServiceId == ServiceId)
                    .Where(form => !form.IsDeleted)
                    .OrderByDescending(form => form.CreatedDate)
                    .Select(form => new FormDTO(
                        form.Id,
                        new ReceiptDTO(
                            form.ReceiptId,
                            form.Receipt.Customer.Name,
                            form.Receipt.DateOrder
                            ),
                        form.ExportDate,
                        form.CreatedDate
                    ))
                    .ToListAsync();

                return Results.Ok(new Response(true, Forms, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
