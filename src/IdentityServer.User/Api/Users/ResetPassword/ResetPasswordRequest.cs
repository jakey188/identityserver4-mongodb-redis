using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Management.Api.Users.ResetPassword
{
    public class ResetPasswordRequest
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

    }
}
