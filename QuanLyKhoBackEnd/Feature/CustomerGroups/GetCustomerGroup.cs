using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.CustomerGroups {
    public class GetCustomerGroup : IEndpoint {
        public record GroupDTO(string Id, string Name, string Description, DateTime DateCreated);
        public record Response(bool Success, GroupDTO? data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Customer-Groups/{id}", Handler).WithTags("Customer Groups");
        }
        [Authorize()]
        private static async Task<IResult> Handler([FromRoute] string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                                .Include(u => u.ServiceRegistered)
                                .Where(u => u.UserName == User.Identity.Name)
                                .Select(u => u.ServiceId)
                                .FirstOrDefaultAsync();

                var Group = await context.CustomerGroups
                    .Where(group => group.ServiceId == ServiceId)
                    .OrderByDescending(group => group.CreatedDate)
                    .Where(group=>!group.IsDeleted)
                    .Where(group => group.Id == id)
                    .Select(group => new GroupDTO(group.Id, group.Name, group.Description, group.CreatedDate))
                    .FirstOrDefaultAsync();

                if (Group != null)
                    return Results.Ok(new Response(true, Group, ""));
                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
