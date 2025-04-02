using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Entity.Vendor_Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.ProductTypes {
    public class AddProductType : IEndpoint {
        public record Request(string Name, string Description);
        public record Response(bool Success, string ErrorMessage, ValidationResult? ValidateError);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Name).NotEmpty().WithMessage("Chưa nhập tên!");
                RuleFor(r => r.Name).MinimumLength(4).WithMessage("Tên phải nhập tối thiểu 4 ký tự!");
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Product-Types", Handler).WithTags("Product Types");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var Validator = new Validator();
                var ValidatedResult = Validator.Validate(request);
                if (!ValidatedResult.IsValid) {
                    return Results.BadRequest(new Response(false, "", ValidatedResult));
                }

                var ServiceId = await context.Users
                       .Include(u => u.ServiceRegistered)
                       .Where(u => u.UserName == User.Identity.Name)
                       .Select(u => u.ServiceId)
                       .FirstOrDefaultAsync();

                ProductType Type = new() {
                    Name = request.Name,
                    Description = request.Description,
                    ServiceId = ServiceId,
                };

                await context.ProductTypes.AddAsync(Type);
                if (await context.SaveChangesAsync() > 0) {
                    return Results.Ok(new Response(true, "", ValidatedResult));
                }

                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!", ValidatedResult));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!", null));
            }
        }
    }
}

