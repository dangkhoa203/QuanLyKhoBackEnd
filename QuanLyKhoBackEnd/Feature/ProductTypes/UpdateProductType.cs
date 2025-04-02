using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.ProductTypes {
    public class UpdateProductType : IEndpoint {
        public record Request(string Id, string Name, string Description);
        public record Response(bool Success, string ErrorMessage, ValidationResult? ValidateError);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Name).NotEmpty().WithMessage("Chưa nhập tên!");
                RuleFor(r => r.Name).MinimumLength(4).WithMessage("Tên phải nhập tối thiểu 4 ký tự!");
            }
            public bool CheckSame(Request request, ProductType type) {
                return (request.Name == type.Name && request.Description == type.Description);
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPut("/api/Product-Types", Handler).WithTags("Product Types");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var Validator = new Validator();
                var ValidatedResult = Validator.Validate(request);
                if (!ValidatedResult.IsValid)
                    return Results.BadRequest(new Response(false, "", ValidatedResult));

                var ServiceId = await context.Users
                        .Include(u => u.ServiceRegistered)
                        .Where(u => u.UserName == User.Identity.Name)
                        .Select(u => u.ServiceId)
                        .FirstOrDefaultAsync();

                var Type = await context.ProductTypes
                    .Where(type => type.ServiceId == ServiceId)
                    .FirstOrDefaultAsync(type => type.Id == request.Id);
                if (Type == null)
                    return Results.NotFound(new Response(false, "Lỗi xảy ra khi đang thực hiện!", ValidatedResult));

                if (!Validator.CheckSame(request, Type)) {
                    Type.Name = request.Name;
                    Type.Description = request.Description;
                    if (await context.SaveChangesAsync() < 1) {
                        return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!", ValidatedResult));
                    }
                }

                return Results.Ok(new Response(true, "", ValidatedResult));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!", null));
            }
        }
    }
}
