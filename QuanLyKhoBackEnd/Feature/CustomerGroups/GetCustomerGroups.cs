using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.CustomerGroups {
    public class GetCustomerGroups : IEndpoint {
        public record GroupDTO(string Id, string Name, DateTime DateCreated,string Description);
        public record Response(bool Success, List<GroupDTO> Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Customer-Groups", Handler).WithTags("Customer Groups");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                                               .Include(u => u.ServiceRegistered)
                                               .Where(u => u.UserName == User.Identity.Name)
                                               .Select(u => u.ServiceId)
                                               .FirstOrDefaultAsync();

                var Groups = await context.CustomerGroups
                    .Where(group => group.ServiceId == ServiceId)
                    .Where(group=>!group.IsDeleted)
                    .OrderByDescending(group => group.CreatedDate)
                    .Select(group => new GroupDTO(group.Id, group.Name, group.CreatedDate,group.Description))
                    .ToListAsync();

                return Results.Ok(new Response(true, Groups, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
