using Microsoft.AspNetCore.Mvc;
using Auth0.AspNetCore.Authentication;

namespace StudiGO.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(string returnUrl = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            return Challenge(authenticationProperties, Auth0Constants.AuthenticationScheme);
        }
    }
}