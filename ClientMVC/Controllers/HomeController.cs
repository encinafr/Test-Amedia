using Client.Services;
using ClientMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _weatherService;

        public HomeController(ILogger<HomeController> logger, IUserService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Settings()
        {
            return View();

        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<List<UserModel>> SendMessage(int roomId, string message)
        {
            var resp = await _weatherService.Get();
            return resp;
        }
    }
}
