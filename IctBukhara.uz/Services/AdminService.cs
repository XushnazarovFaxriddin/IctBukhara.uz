using IctBukhara.uz.Data;
using IctBukhara.uz.Helpers;
using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using IctBukhara.uz.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IctBukhara.uz.Services
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _dbContext;
        private readonly IWebHostEnvironment _webHost;

        public AdminService(DataContext _dataContext, IWebHostEnvironment webHost)
        {
            this._dbContext = _dataContext;
            this._webHost = webHost;
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorlarAsync() => _dbContext.Mentorlar;

        public async Task<IEnumerable<Kurs>> GetAllKurslarAsync() => _dbContext.Kurslar.Include(k => k.Mentor);

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var admin = await _dbContext.Admins.FirstOrDefaultAsync(x => x.Id == id);
            if (admin is null)
                throw new Exception("Bunday admin mavjud emas!");
            return admin;
        }
        public async Task<Mentor> GetMentorByIdAsync(int id)
        {
            var mentor = await _dbContext.Mentorlar.FirstOrDefaultAsync(m => m.Id == id);
            if (mentor is null)
                throw new Exception("Bunday mentor mavjud emas!");
            return mentor;
        }
        public async Task<Kurs> GetKursByIdAsync(int id)
        {
            var kurs = await _dbContext.Kurslar.FirstOrDefaultAsync(k => k.Id == id);
            if (kurs is null)
                throw new Exception("Bunday kurs mavjud emas!");
            return kurs;
        }

        public async Task AddMentorAsync(PostMentor pmentor)
        {
            if (pmentor is null)
                throw new Exception("Malumotlarni to'ldiring!");
            Mentor mentor = new Mentor();
            mentor.FullName = pmentor.FullName;
            mentor.Discription = pmentor.Discription;
            mentor.Cv = pmentor.Cv;
            mentor.CvUrl = pmentor.CvUrl;

            string uniqueImageName = string.Empty;
            uniqueImageName = Guid.NewGuid().ToString() + "_" + pmentor.Image.FileName;
            uniqueImageName = Path.Combine("images", "mentorlar", uniqueImageName);
            string inputImagePath = Path.Combine(_webHost.WebRootPath, uniqueImageName);
            using (var stream = System.IO.File.Create(inputImagePath))
            {
                await pmentor.Image.CopyToAsync(stream);
            }

            mentor.ImageName = uniqueImageName;
            _dbContext.Mentorlar.Add(mentor);
            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateMentorAsync(EditMentorPost editMentor)
        {
            var mentor = await GetMentorByIdAsync(editMentor.Id);
            if(editMentor.Image is not null)
            {
                var imagePath = Path.Combine(_webHost.WebRootPath, mentor.ImageName);
                System.IO.File.Delete(imagePath);
                using(var stream = System.IO.File.Create(imagePath))
                {
                    await editMentor.Image.CopyToAsync(stream);
                }
            }
            mentor.FullName = editMentor.FullName;
            mentor.Cv = editMentor.Cv;
            mentor.CvUrl = editMentor.CvUrl;
            mentor.Discription=editMentor.Discription;

            _dbContext.Mentorlar.Update(mentor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateKursAsync(EditKursPost kursEdit)
        {
            var kurs = await GetKursByIdAsync(kursEdit.Id);
            if (kursEdit.Image is not null)
            {
                var imagePath = Path.Combine(_webHost.WebRootPath, kurs.ImageName);
                System.IO.File.Delete(imagePath);
                using (var stream = System.IO.File.Create(imagePath))
                {
                    await kursEdit.Image.CopyToAsync(stream);
                }
            }

            kurs.Name=kursEdit.Name;
            kurs.Discription=kursEdit.Discription;
            kurs.Duration=kursEdit.Duration;
            kurs.Learning=kursEdit.Learning;
            kurs.MentorId=kursEdit.MentorId;
            _dbContext.Kurslar.Update(kurs);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteMentorAsync(int id)
        {
            var mentor = await _dbContext.Mentorlar.FirstOrDefaultAsync(a => a.Id == id);
            if (mentor is null)
                throw new Exception("Bunday mentor mavjud emas!");
            try
            {
                await _dbContext.Kurslar.Where(x => x.MentorId == mentor.Id).ForEachAsync(async kurs =>
                {
                    try
                    {
                        System.IO.File.Delete(Path.Combine(_webHost.WebRootPath, kurs.ImageName));
                    }
                    catch
                    {
                        // shu rasm o'chmadi yoki bunday rasm yoq
                    }
                });
                System.IO.File.Delete(Path.Combine(_webHost.WebRootPath, mentor.ImageName));
            }
            finally
            {
                _dbContext.Mentorlar.Remove(mentor);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task AddKursAsync(PostKurs kurs)
        {
            if (kurs is null)
                throw new Exception("Malumotlarni kiriting!");
            Kurs k = new Kurs();
            k.Name = kurs.Name;
            k.Discription = kurs.Discription;
            k.Duration = kurs.Duration;
            k.Learning = kurs.Learning;
            k.MentorId = kurs.MentorId;

            string uniqueImageName = Guid.NewGuid().ToString() + "_" + kurs.Image.FileName;
            uniqueImageName = Path.Combine("images", "kurslar", uniqueImageName);
            string inputFileName = Path.Combine(_webHost.WebRootPath, uniqueImageName);
            using (var stream = System.IO.File.Create(inputFileName))
            {
                await kurs.Image.CopyToAsync(stream);
            }

            k.ImageName = uniqueImageName;
            _dbContext.Kurslar.Add(k);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteKursAsync(int id)
        {
            var kurs = await _dbContext.Kurslar.FirstOrDefaultAsync(k => k.Id == id);
            if (kurs is null)
                throw new Exception("Bunday kurs mavjud emas!");
            try
            {
                System.IO.File.Delete(Path.Combine(_webHost.WebRootPath, kurs.ImageName));
            }
            finally
            {
                _dbContext.Kurslar.Remove(kurs);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubscriptionKurs>> GetAllKursgaYozilganlarAsync()
            =>  _dbContext.KursgaYozilganlar.Where(k => !k.IsDelete);
        public async Task DeleteKursgaYozilganByIdAsync(int id)
        {
            var klient = await _dbContext.KursgaYozilganlar.FirstOrDefaultAsync(k => k.Id == id);
            if (klient is null)
                throw new Exception("Bunday kursga yozilgan talab mavjud emas!");
            klient.IsDelete = true;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Admin> LoginAsync(LoginModel model)
        {
            if (model is null)
                throw new Exception("Login yoki parol xato! (form null)");
            var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Login == model.login);
            if (admin is null)
                throw new Exception("Login yoki parol xato! (form logn)");
            //if(!CyriptoHelper.Verify(model.password, admin.Password))
            if (model.password != admin.Password)
                throw new Exception("Login yoki parol xato! (form password)");

            admin.Token = Guid.NewGuid().ToString();
            await _dbContext.SaveChangesAsync();
            return admin;
        }

        public async Task LogoutAsync(int id)
        {
            var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Id == id);
            if (admin is null)
                throw new Exception("Tizimda bunday Admin mavjud emas!");
            admin.Token = "Admin tizimdan chiqib ketdi! " + Guid.NewGuid().ToString();
            _dbContext.Admins.Update(admin);
            await _dbContext.SaveChangesAsync();
        }
    }
}
