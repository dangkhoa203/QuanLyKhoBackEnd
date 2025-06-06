﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.VendorReplenishReceipts {
    public class GetVendorReceipts : IEndpoint {
        public record vendorDTO(string id, string name, string email, string address, string phoneNumber);
        public record receiptDTO(string id, vendorDTO Vendor, DateTime dateOfOrder,DateTime dateCreated);
        public record Response(bool Success, List<receiptDTO> data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Vendor-Receipts", Handler).WithTags("Vendor Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                    .Include(u => u.ServiceRegistered)
                    .Where(u => u.UserName == User.Identity.Name)
                    .Select(u => u.ServiceId)
                    .FirstOrDefaultAsync();

                var Receipts = await context.VendorReplenishReceipts
                    .Include(receipt => receipt.Vendor)
                    .Where(receipt => receipt.ServiceId == ServiceId)
                    .Where(receipt => !receipt.IsDeleted)
                    .OrderByDescending(receipt => receipt.CreatedDate)
                    .Select(receipt => new receiptDTO(
                        receipt.Id,
                        new vendorDTO(
                            receipt.Vendor.Id,
                            receipt.Vendor.Name,
                            receipt.Vendor.Email,
                            receipt.Vendor.Address,
                            receipt.Vendor.PhoneNumber
                            ),
                        receipt.DateOrder,
                        receipt.CreatedDate
                    ))
                    .ToListAsync();

                return Results.Ok(new Response(true, Receipts, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
