using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Products {
    public class AddProduct {
        public record Request(string Name, int PricePerUnit, string MeasureUnit, string? TypeId);
        public record Response(bool Success, string ErrorMessage, ValidationResult? ValidateError);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Name)
                    .MinimumLength(4).WithMessage("Tên phải có tối thiểu 4 ký tự!")
                    .NotEmpty().WithMessage("Chưa nhập tên");
                RuleFor(r => r.PricePerUnit).GreaterThan(-1).WithMessage("Giá chưa phù hợp");
                RuleFor(r => r.MeasureUnit).NotEmpty().WithMessage("Chưa nhập đơn vị tính");
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Products", Handler).WithTags("Products");
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

                Product Product = new() {
                    Name = request.Name,
                    MeasureUnit = request.MeasureUnit,
                    PricePerUnit = request.PricePerUnit,
                    ProductType = await context.ProductTypes.FindAsync(request.TypeId),
                    ServiceId = ServiceId,
                };
                await context.Products.AddAsync(Product);

                if (await context.SaveChangesAsync() > 0) {
                    return Results.Ok(new Response(true, "", ValidatedResult));
                }

                return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!", ValidatedResult));
            }
            catch {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!", null));
            } 
        }

    }
}
