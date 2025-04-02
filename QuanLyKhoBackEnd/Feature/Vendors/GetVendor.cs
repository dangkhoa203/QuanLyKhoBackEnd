using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Vendors {
    public class GetVendor : IEndpoint {
        public record GroupDTO(string Id, string Name, string Description);
        public record VendorDTO(string Id, string Name, string Email, string Address, string PhoneNumber, GroupDTO? Group, DateTime DateCreated);
        public record Response(bool Success, VendorDTO data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Vendors/{id}", Handler).WithTags("Vendors");
        }
        [Authorize()]
        private static async Task<IResult> Handler(string id, ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                   .Include(u => u.ServiceRegistered)
                   .Where(u => u.UserName == User.Identity.Name)
                   .Select(u => u.ServiceId)
                   .FirstOrDefaultAsync();

                var Vendor = await context.Vendors
                    .Where(vendor => vendor.ServiceId == ServiceId)
                    .Where(Vendor=>!Vendor.IsDeleted)
                    .Where(vendor => vendor.Id == id)
                    .Include(vendor => vendor.VendorGroup)
                    .Select(vendor => new VendorDTO(
                        vendor.Id,
                        vendor.Name,
                        vendor.Email,
                        vendor.Address,
                        vendor.PhoneNumber,
                        vendor.VendorGroup != null ? new GroupDTO(vendor.VendorGroup.Id, vendor.VendorGroup.Name, vendor.VendorGroup.Description) : null,
                        vendor.CreatedDate
                     ))
                    .FirstOrDefaultAsync();

                if (Vendor != null)
                    return Results.Ok(new Response(true, Vendor, ""));

                return Results.NotFound(new Response(false, null, "Không tìm thấy dữ liệu!"));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, null, "Lỗi đã xảy ra!"));
            }
        }
    }
}
