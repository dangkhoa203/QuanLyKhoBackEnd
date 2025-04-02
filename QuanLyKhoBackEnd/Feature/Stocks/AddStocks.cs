using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Stocks {
    public class AddStocks : IEndpoint {
        public record Request(string ProductId, int Quantity);
        public record Response(bool Success, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Stocks", Handler).WithTags("Stocks");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                if (request.Quantity < 0)
                    return Results.BadRequest(new Response(false, "Số lượng không đủ!"));

                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                var StockCheck = context.Stocks.FirstOrDefault(s => s.ProductId == request.ProductId );
                if (StockCheck == null) {
                    var Product = await context.Products
                                                .Where(product => product.ServiceId == ServiceId)
                                                .FirstOrDefaultAsync(product => product.Id == request.ProductId);

                 

                    if (Product == null ) {
                        return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!"));
                    }

                    var Stock = new Stock() {
                        ProductNav = Product,
                        Quantity = request.Quantity,
                        ServiceId = ServiceId
                    };
                    await context.Stocks.AddAsync(Stock);
                    if (await context.SaveChangesAsync() > 0) {
                        return Results.Ok(new Response(true, ""));
                    }
                }

                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!"));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }
        }
    }
}
