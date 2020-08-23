using mDome.API.Database;
using mDome.API.Services;
using mDome.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace mDome.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        AdministratorLoginService _adminService;
        UserProfileService _userService;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ICRUDService<Model.AdministratorLogin, AdminSearchRequest, AdminUpsertRequest, AdminUpsertRequest> adminService,
            ICRUDService<Model.UserProfile, UserProfileSearchRequest, UserProfileUpsertRequest, UserProfileUpsertRequest> userService)
            : base(options, logger, encoder, clock)
        {

            _adminService = (AdministratorLoginService)adminService;
            _userService = (UserProfileService)userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            Model.UserProfile user = null;
            Model.AdministratorLogin admin = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                user = _userService.Authenticate(username, password);
                admin = _adminService.Authenticate(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null && admin == null)
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }
            if (admin != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, admin.AdminName),
                new Claim(ClaimTypes.Email, admin.AdminName+"@mdome.com"),
            };
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            else
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }

            
        }
    }
}
