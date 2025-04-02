﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Customers {
    public class RemoveCustomer : IEndpoint {
        public record Request(string Id);
        public record Response(bool Success, string ErrorMessage);
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapDelete("/api/Customers/", Handler).WithTags("Customers");
        }
        [Authorize()]
        private static async Task<IResult> Handler([FromBody] Request request, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                 .Include(u => u.ServiceRegistered)
                 .Where(u => u.UserName == User.Identity.Name)
                 .Select(u => u.ServiceId)
                 .FirstOrDefaultAsync();

                var Customer = await context.Customers
                    .Where(customer => customer.ServiceId == ServiceId)
                    .FirstOrDefaultAsync(customer => customer.Id == request.Id);

                if (Customer != null) {
                    Customer.IsDeleted = true;
                    Customer.DeletedAt = DateTime.Now;
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
