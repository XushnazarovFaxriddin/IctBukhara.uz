using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using IctBukhara.uz.Models.ViewModels;
using IctBukhara.uz.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IctBukhara.uz.Controllers
{

    public class HomeController : Controller
    {

        private readonly IAdminService _adminService;
        private readonly IHomeService _homeService;
        public HomeController(IAdminService adminService, IHomeService homeService)
        {
            _adminService = adminService;
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                return View(new IndexView
                {
                    Kurslar = await _adminService.GetAllKurslarAsync(),
                    Mentorlar = await _adminService.GetAllMentorlarAsync()
                });
            }
            catch (Exception e)
            {
                return Redirect("/404.html?error=" + e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BarchaKurslar()
        {
            try
            {
                return View(await _adminService.GetAllKurslarAsync());
            }
            catch (Exception e) { return RedirectToAction("Not_Found", "Other"); }
        }

        [HttpGet]
        public async Task<IActionResult> Kurs([FromQuery] int id)
        {
            try
            {
                ViewData["Kurs"] = await _adminService.GetKursByIdAsync(id) ?? throw new Exception("Bunday kurs mavjud emas!");
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Not_Found", "Other");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Kurs(SubscriptionKurs subscription)
        {
            try
            {
                ViewData["Kurs"] = await _adminService.GetKursByIdAsync(subscription.KursId);
                
                if (!ModelState.IsValid)
                {
                    ViewData["ErrorSendMessage"] = new ErrorSendMessage
                    {
                        Error = true,
                        Message = " -- "
                    };
                    return View();
                }
                 ViewData["ErrorSendMessage"] = new ErrorSendMessage
                {
                    Error = false,
                    Message = "Muvaffaqiyatli yuborildi"
                };

                await _homeService.SubscriptionKursAsync(subscription);

                return View();
            }
            catch (Exception ex)
            {
                try
                {
                    ViewData["Kurs"] = await _adminService.GetKursByIdAsync(subscription.KursId);
                    ViewData["ErrorSendMessage"] = new ErrorSendMessage
                    {
                        Error = true,
                        Message = ex.Message
                    };
                    return View();
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true), HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
