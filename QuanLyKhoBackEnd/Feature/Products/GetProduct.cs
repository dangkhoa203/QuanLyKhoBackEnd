using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Products {
    public class GetProduct : IEndpoint {
        public record TypeDTO(string Id, string Name, string Description);
        public record ProductDTO(string Id, string Name, float PricePerUnit, string MeasureUnit, TypeDTO? Type, DateTime DateCreated);
        public record Response(bool Success, ProductDTO Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Products/{id}", Handler).WithTags("Products");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Product = await context.Products
                    .Include(product => product.ProductType)
                    .Where(product => product.ServiceId == ServiceId)
                    .Where(product=>!product.IsDeleted)
                    .Where(product => product.Id == id)
                    .OrderByDescending(product => product.CreatedDate)
                    .Select(product => new ProductDTO(
                        product.Id,
                        product.Name,
                        product.PricePerUnit,
                        product.MeasureUnit,
                        product.ProductType != null ?
                        new TypeDTO(product.ProductType.Id, product.ProductType.Name, product.ProductType.Description) : null,
                        product.CreatedDate
                        )
                    )
                    .FirstOrDefaultAsync();

                return Results.Ok(new Response(true, Product, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
