using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using System.Threading.Tasks;

namespace IctBukhara.uz.Services.Interfaces
{
    public interface IHomeService
    {
        public Task SubscriptionKursAsync(SubscriptionKurs subscriptionKurs);
    }
}
