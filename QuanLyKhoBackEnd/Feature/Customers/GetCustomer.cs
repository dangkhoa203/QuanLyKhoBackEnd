using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Customers
{
    public class GetCustomer:IEndpoint
    {
        public record GroupDTO(string Id,string Name,string Description);
        public record CustomerDTO(string Id, string Name, string Email, string Address, string PhoneNumber, GroupDTO? Group, DateTime DateCreated);
        public record Response(bool Success, CustomerDTO Data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/Customers/{id}", Handler).WithTags("Customers");
        }
        [Authorize()]
        private static async Task<IResult> Handler([FromRoute]string id,ApplicationDbContext context, ClaimsPrincipal User)
        {
            try
            {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Customer = await context.Customers
                    .Include(customer => customer.CustomerGroup)
                    .Where(customer => customer.ServiceId == ServiceId)
                    .Where(customer=>!customer.IsDeleted)
                    .Where(customer => customer.Id == id)
                    .Select(customer => new CustomerDTO(
                        customer.Id,
                        customer.Name,
                        customer.Email,
                        customer.Address,
                        customer.PhoneNumber,
                        customer.CustomerGroup != null ? new GroupDTO(customer.CustomerGroup.Id, customer.CustomerGroup.Name, customer.CustomerGroup.Description) : null,
                        customer.CreatedDate
                     ))
                    .FirstOrDefaultAsync();

                if (Customer != null)
                    return Results.Ok(new Response(true, Customer, ""));

                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
