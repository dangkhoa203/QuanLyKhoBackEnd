﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.CustomerGroups {
    public class UpdateCustomerGroup : IEndpoint {
        public record Request(string Id, string Name, string Description);
        public record Response(bool Success, string ErrorMessage, ValidationResult? ValidateError);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Name).NotEmpty().WithMessage("Chưa nhập tên");
                RuleFor(r => r.Name).MinimumLength(4).WithMessage("Tên phải nhập tối thiểu 4 ký tự!");
            }
            public bool CheckSame(Request request, CustomerGroup group) {
                return (request.Name == group.Name && request.Description == group.Description);
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPut("/api/Customer-Groups", Handler).WithTags("Customer Groups");
        }
        [Authorize()]
        private static async Task<IResult> Handler(Request request,ApplicationDbContext context,ClaimsPrincipal User) {
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

                var Group = await context.CustomerGroups
                    .Where(group => group.ServiceId == ServiceId)
                    .Include(group => group.Customers)
                    .FirstOrDefaultAsync(group => group.Id == request.Id);
                if (Group == null)
                    return Results.NotFound(new Response(false, "Không tìm thấy nhóm!", ValidatedResult));

                if (!Validator.CheckSame(request, Group)) {
                    Group.Name = request.Name;
                    Group.Description = request.Description;
                    if (await context.SaveChangesAsync() < 1) {
                        return Results.BadRequest(new Response(false, "Lỗi xảy ra khi đang thực hiện!", ValidatedResult));
                    }
                }
                return Results.Ok(new Response(true, "", ValidatedResult));
            }
            catch (Exception) {
                return Results.NotFound(new Response(false, "Lỗi server đã xảy ra!", null));
            }
        }
    }
}
