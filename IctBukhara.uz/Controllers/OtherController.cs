using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using IctBukhara.uz.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IctBukhara.uz.Controllers
{
    public class OtherController : Controller
    {
        private readonly IAdminService _adminService;
        public OtherController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? msg) => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                ViewBag.ErrorLogin = false;

                var admin = await _adminService.LoginAsync(model);
                HttpContext.Session.SetInt32("id", admin.Id);
                HttpContext.Session.SetString("name", admin.Name);
                HttpContext.Session.SetString("login", admin.Login);
                HttpContext.Session.SetString("token", admin.Token);

                return RedirectToAction("Index","Admin");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorLogin = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout(int id)
        {
            try
            {
                await _adminService.LogoutAsync(id);
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Other");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Admin");
            }
        }

        [HttpGet, Route("Other/NotFound")]
        public async Task<IActionResult> Not_Found() => View();

        [HttpGet]
        public async Task<IActionResult> Error([FromQuery] string? mes) => View();
    }
}
