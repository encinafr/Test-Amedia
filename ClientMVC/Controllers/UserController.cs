using Client.Services;
using ClientMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ClientMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.Get();
            return View(users);
        }

        public async Task<IActionResult> AddOrEdit(int? userId)
        {
            ViewBag.PageName = userId == null ? "Create User" : "Edit User";
            ViewBag.IsEdit = userId == null ? false : true;

            if (userId == null)
            {
                return View();
            }
            else
            {
                var user = await _userService.Get(userId.Value);

                if (user == null)
                    return NotFound();
                
                return View(user);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int userId, [Bind("Txt_nombre,Txt_apellido,Txt_user,Nro_doc,Txt_password,Cod_rol")]UserModel userData)
        {
            bool IsUserExist = false;

            UserModel user = await _userService.Get(userId);

            if (user != null)
            {
                IsUserExist = true;
            }
            else
            {
                user = new UserModel();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.Txt_nombre = userData.Txt_nombre;
                    user.Txt_apellido = userData.Txt_apellido;
                    user.Txt_user = userData.Txt_user;
                    user.Nro_doc = userData.Nro_doc;
                    user.Txt_password = "1234"; //TODO Crear password, recuperar pass etc
                    user.Cod_rol = userData.Cod_rol;

                    if (IsUserExist)
                    {
                       await _userService.Update(userId, user);
                    }
                    else
                    {
                       await _userService.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userData);
        }

        public async Task<IActionResult> Details(int? userId)
        {
            if (userId == null)
                return NotFound();
            
            var User = await _userService.Get(userId.Value);
            
            if (User == null)
                return NotFound();

            return View(User);
        }

        public async Task<IActionResult> Delete(int? userId)
        {
            if (userId == null)
                return NotFound();
            
            var User = await _userService.Get(userId.Value);

            return View(User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int userId)
        {
            await _userService.Delete(userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
