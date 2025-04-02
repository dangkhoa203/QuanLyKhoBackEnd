using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Stocks {
    public class GetStocks : IEndpoint {
        public record StockDTO(string ProductId, string ProductName, int Quantity);
        public record Response(bool Success, List<StockDTO> data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Stocks", Handler).WithTags("Stocks");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Stocks = await context.Stocks
                    .Where(stock => stock.ServiceId == ServiceId)
                    .Include(stock => stock.ProductNav)
                    .Select(stock => new StockDTO(stock.ProductId, stock.ProductNav.Name, stock.Quantity))
                    .ToListAsync();

                return Results.Ok(new Response(true, Stocks, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
