﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QuanLyKhoBackEnd.Data;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.CustomerBuyReceipts {
    public class GetCustomerReceipts : IEndpoint {
        public record CustomerDTO(string Id, string Name, string Email, string Address, string PhoneNumber);
        public record ReceiptDTO(string id, CustomerDTO customer, DateTime dateOfOrder,DateTime DateCreated);
        public record Response(bool Success, List<ReceiptDTO> data, string ErrorMessage);

        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapGet("/api/Customer-Receipts", Handler).WithTags("Customer Receipts");
        }
        [Authorize()]
        private static async Task<IResult> Handler(ApplicationDbContext context, ClaimsPrincipal User) {
            try {
                var ServiceId = await context.Users
                                .Include(u => u.ServiceRegistered)
                                .Where(u => u.UserName == User.Identity.Name)
                                .Select(u => u.ServiceId)
                                .FirstOrDefaultAsync();

                var Receipts = await context.CustomerBuyReceipts
                    .Include(receipt => receipt.Customer)
                    .Where(receipt => receipt.ServiceId == ServiceId)
                    .Where(receipt=>!receipt.IsDeleted)
                    .OrderByDescending(receipt => receipt.CreatedDate)
                    .Select(receipt => new ReceiptDTO(
                        receipt.Id,
                        new CustomerDTO(
                            receipt.Customer.Id,
                            receipt.Customer.Name,
                            receipt.Customer.Email,
                            receipt.Customer.Address,
                            receipt.Customer.PhoneNumber
                            ),
                        receipt.DateOrder,
                        receipt.CreatedDate
                    )).ToListAsync();

                return Results.Ok(new Response(true, Receipts, ""));
            }
            catch (Exception ex) {
                return Results.BadRequest(new Response(false, [], "Lỗi đã xảy ra!"));
            }
        }
    }
}
