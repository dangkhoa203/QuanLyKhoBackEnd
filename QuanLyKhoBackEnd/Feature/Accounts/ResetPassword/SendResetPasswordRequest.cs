using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using QuanLyKhoBackEnd.Endpoint;
using QuanLyKhoBackEnd.Middleware;
using QuanLyKhoBackEnd.Model.Entity.Account;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Feature.Accounts.ResetPassword {
    public class SendResetPasswordRequest : IEndpoint {
        public record Request(string Email);
        public record Response(bool Success, string ErrorMessage);
        public sealed class Validator : AbstractValidator<Request> {
            public Validator() {
                RuleFor(r => r.Email).EmailAddress();
            }
        }
        public static void MapEndpoint(IEndpointRouteBuilder app) {
            app.MapPost("/api/Account/PasswordReset/", Handler).WithTags("Account");
        }
        private static async Task<IResult> Handler(Request request, UserManager<Account> userManager, EmailSender emailSender) {
            try {
                var Validator = new Validator();
                var ValidateResult = await Validator.ValidateAsync(request);
                if (!ValidateResult.IsValid) {
                    return Results.BadRequest(new Response(false, "Email chưa hợp lệ"));
                }

                Account User = await userManager.FindByEmailAsync(request.Email);
                if (User == null) {
                    return Results.NotFound(new Response(false, "Không có tài khoản với email này!"));
                }

                var Token = await userManager.GeneratePasswordResetTokenAsync(User);
                Token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(Token));
                var ConfirmLink = $"https://dkwarehouse.vercel.app/ResetMatKhau/{WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(User.Id))}/{Token}";

                bool EmailResponse = await emailSender.SendEmail(request.Email, "Xác nhận reset mật khẩu","Nhấn vào nút này để vào reset mật khẩu tài khoản.",ConfirmLink,"Thay đổi");
                if (!EmailResponse) {
                    return Results.BadRequest(new Response(false, "Lỗi đã xảy ra!"));
                }

                return Results.Ok(new Response(true, ""));
            }
            catch (Exception) {
                return Results.BadRequest(new Response(false, "Lỗi server đã xảy ra!"));
            }

        }
    }
}
