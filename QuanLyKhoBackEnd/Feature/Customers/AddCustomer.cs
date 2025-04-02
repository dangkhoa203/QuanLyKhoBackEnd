using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QuanLyKhoBackEnd.Model.Entity;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Customers {
    public class AddCustomer : IEndpoint {
        public record Request(string Name, string Address, string Email, string PhoneNumber, string? GroupId);
        public record Response(bool Success, string ErrorMessage, ValidationResult? ValidateError);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Name).NotEmpty().WithMessage("Chưa nhập tên");
                RuleFor(r => r.Name).MinimumLength(4).WithMessage("Tên phải nhập tối thiểu 4 ký tự!");
                RuleFor(r => r.PhoneNumber)
                    .Length(10).WithMessage("Số điện thoại phải có độ dài là 10!")
                    .Must(x => int.TryParse(x, out var val) && val > 0).WithMessage("Số điện thoại chưa hợp lệ!");
                RuleFor(r => r.Email).EmailAddress().WithMessage("Email chưa hợp lệ");
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Customers", Handler).WithTags("Customers");
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

                Customer Customer = new() {
                    Address = request.Address,
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    CustomerGroup = await context.CustomerGroups.FindAsync(request.GroupId),
                    ServiceId = ServiceId,
                };
                await context.Customers.AddAsync(Customer);

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
