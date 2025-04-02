using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Stocks {
    public class RemoveStock : IEndpoint {
        public record Request(string ProductId);
        public record Response(bool Success, string ErrorMessage);
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapDelete("/api/Stocks/", Handler).WithTags("Stocks");
        }
        [Authorize()]
        private static async Task<IResult> Handler([FromBody] Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                var Stock = await context.Stocks
                    .Where(stock => stock.ServiceId == ServiceId)
                    .FirstOrDefaultAsync(stock => stock.ProductId == request.ProductId);

                if (Stock != null) {
                    context.Stocks.Remove(Stock);
                    var Result = await context.SaveChangesAsync();
                    if (Result > 0)
                        return Results.Ok(new Response(true, ""));
                    return Results.BadRequest(new Response(false, "Lỗi đã xảy ra!"));
                }

                return Results.NotFound(new Response(false, "Không tìm thấy nhóm!"));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }
        }
    }
}
