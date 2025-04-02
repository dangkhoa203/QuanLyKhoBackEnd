using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.ProductTypes {
    public class GetProductType : IEndpoint {
        public record TypeDTO(string Id, string Name, string Description, DateTime DateCreated);
        public record Response(bool Success, TypeDTO Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Product-Types/{id}", Handler).WithTags("Product Types");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Type = await context.ProductTypes
                    .Where(type => type.ServiceId == ServiceId)
                    .Where(type=>!type.IsDeleted)
                    .Where(type => type.Id == id)
                    .Select(type => new TypeDTO(type.Id, type.Name, type.Description, type.CreatedDate))
                    .FirstOrDefaultAsync();

                if (Type != null)
                    return Results.Ok(new Response(true, Type, ""));

                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
