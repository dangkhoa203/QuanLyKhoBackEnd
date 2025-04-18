﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Model.Entity.Account;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Accounts.ResetPassword {
    public class CheckAccountForReset : IEndpoint {
        public record Response(bool Success);
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Account/PasswordReset/ResetValidation/{userid}/", Handler).WithTags("Account");
        }
        private static async Task<IResult> Handler([FromRoute] string userid, UserManager<Account> userManager) {
            try {
                Account User = await userManager.FindByIdAsync(Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(userid)));

                if (User != null ) {
                    return Results.Ok(new Response(true));
                }

                return Results.Ok(new Response(false));
            }
            catch (Exception) {
                return Results.Ok(new Response(false));
            }

        }
    }
}
