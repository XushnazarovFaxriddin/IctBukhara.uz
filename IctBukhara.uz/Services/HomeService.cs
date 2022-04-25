using IctBukhara.uz.Data;
using IctBukhara.uz.Models.PostModels;
using IctBukhara.uz.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace IctBukhara.uz.Services
{
    public class HomeService : IHomeService
    {
        private readonly DataContext _dbContext;
        private readonly IWebHostEnvironment _webHost;

        public HomeService(DataContext _dataContext, IWebHostEnvironment webHost)
        {
            this._dbContext = _dataContext;
            this._webHost = webHost;
        }
        public async Task SubscriptionKursAsync(SubscriptionKurs subscriptionKurs)
        {
            if (subscriptionKurs is null)
                throw new Exception("Malumotlarni to'liq yuboring!");
            //subscriptionKurs.Vaqt = DateTime.Now;
            _dbContext.KursgaYozilganlar.Add(subscriptionKurs);
            await _dbContext.SaveChangesAsync();
        }
    }
}
