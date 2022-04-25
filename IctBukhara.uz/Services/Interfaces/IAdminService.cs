using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IctBukhara.uz.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<IEnumerable<Mentor>> GetAllMentorlarAsync();
        public Task<IEnumerable<Kurs>> GetAllKurslarAsync();
        public Task<Admin> GetAdminByIdAsync(int id); 
        public Task<Mentor> GetMentorByIdAsync(int id);
        public Task<Kurs> GetKursByIdAsync(int id);
        public Task<IEnumerable<SubscriptionKurs>> GetAllKursgaYozilganlarAsync();

        public Task DeleteKursgaYozilganByIdAsync(int id);

        public Task AddMentorAsync(PostMentor mentor);

        public Task AddKursAsync(PostKurs kurs);

        public Task DeleteKursAsync(int id);

        public Task UpdateMentorAsync(EditMentorPost mentor);

        public Task UpdateKursAsync(EditKursPost kurs);

        public Task DeleteMentorAsync(int id);
        public Task<Admin> LoginAsync(LoginModel model);
        public Task LogoutAsync(int id);
    }
}
