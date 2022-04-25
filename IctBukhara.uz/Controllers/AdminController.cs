using IctBukhara.uz.Entitys;
using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using IctBukhara.uz.Models.ViewModels;
using IctBukhara.uz.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IctBukhara.uz.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? msg)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Kurslar()
        {
            try
            {
                return View((await _adminService.GetAllKurslarAsync()));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mentorlar()
        {
            try
            {
                return View((await _adminService.GetAllMentorlarAsync())?.Reverse());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMentor(PostMentor mentor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                await _adminService.AddMentorAsync(mentor);
                return RedirectToAction("Mentorlar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddMentor() => View();


        [HttpPost]
        public async Task<IActionResult> DeleteMentor([FromQuery] int id)
        {
            try
            {
                await _adminService.DeleteMentorAsync(id);
                return RedirectToAction("Mentorlar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteKurs([FromQuery] int id)
        {
            try
            {
                await _adminService.DeleteKursAsync(id);
                return RedirectToAction("Kurslar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddKurs()
        {
            try
            {
                List<MentorSelect> mentorSelects = new();
                (await _adminService.GetAllMentorlarAsync()).ToList().ForEach(m =>
                    mentorSelects.Add(new MentorSelect
                    {
                        Id = m.Id,
                        Name = m.FullName
                    }));

                ViewData["MentorSelect"] = mentorSelects;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddKurs(PostKurs kurs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<MentorSelect> mentorSelects = new();
                    (await _adminService.GetAllMentorlarAsync()).ToList().ForEach(m =>
                        mentorSelects.Add(new MentorSelect
                        {
                            Id = m.Id,
                            Name = m.FullName
                        }));

                    ViewData["MentorSelect"] = mentorSelects;
                    return View();
                }

                await _adminService.AddKursAsync(kurs);
                return RedirectToAction("Kurslar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditMentor([FromQuery] int id)
        {
            try
            {
                ViewData["Mentor"] = await _adminService.GetMentorByIdAsync(id);
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditMentor(EditMentorPost editMentor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["Mentor"] = await _adminService.GetMentorByIdAsync(editMentor.Id);
                    return View();
                }
                await _adminService.UpdateMentorAsync(editMentor);
                return RedirectToAction("Mentorlar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpGet()]
        public async Task<IActionResult> EditKurs([FromQuery(Name = "id")] int id)
        {
            try
            {
                ViewData["Kurs"] = await _adminService.GetKursByIdAsync(id);
                List<MentorSelect> mentorSelects = new();
                (await _adminService.GetAllMentorlarAsync()).ToList().ForEach(m =>
                    mentorSelects.Add(new MentorSelect
                    {
                        Id = m.Id,
                        Name = m.FullName
                    }));

                ViewData["MentorSelect"] = mentorSelects;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditKurs(EditKursPost editKurs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["Kurs"] = await _adminService.GetKursByIdAsync(editKurs.Id);
                    List<MentorSelect> mentorSelects = new();
                    (await _adminService.GetAllMentorlarAsync()).ToList().ForEach(m =>
                        mentorSelects.Add(new MentorSelect
                        {
                            Id = m.Id,
                            Name = m.FullName
                        }));

                    ViewData["MentorSelect"] = mentorSelects;
                    return View();
                }
                await _adminService.UpdateKursAsync(editKurs);
                return RedirectToAction("Kurslar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> KursgaYozilganlar()
        {
            try
            {
                return View((await _adminService.GetAllKursgaYozilganlarAsync()).Reverse());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> KursgaYozilgan(int id)
        {
            try
            {
                await _adminService.DeleteKursgaYozilganByIdAsync(id);
                return RedirectToAction("KursgaYozilganlar", "Admin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Admin", new { msg = ex.Message });
            }
        }
    }
}
