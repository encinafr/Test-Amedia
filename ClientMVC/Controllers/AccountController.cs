using Client.Services;
using ClientMVC.Common.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClientMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var roleUser = User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

             if(roleUser != null && roleUser != "User")
                return RedirectToAction(actionName: "Index", controllerName: "Home");

            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }

            //TODO: crear account service
            var user = await _userService.Login(new Common.Dto.LoginDto { User = username, Password = password });

            ClaimsIdentity identity = null;

            if (user.Cod_rol == (int)RolEnum.Administrador)
            {

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Success");
            }

            if (user.Cod_rol == (int)RolEnum.Usuario)
            {
                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "User")
            }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction(actionName: "Index", controllerName: "User");
            }



            return View("Index");
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
