using IctBukhara.uz.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IctBukhara.uz.Models.PostModels
{
    using System;
    public class SubscriptionKurs
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ism Familya bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Ism Familya kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Ism Familya ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Ism Familya")]
        public string Name { get; set; }

        [DisplayName("Telefon raqam"),TelRange()]
        public long Tel { get; set; }
        public int KursId { get; set; }

        [Required(ErrorMessage = "Kurs nomi bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Kurs nomi kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Kurs nomi ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Kurs nomi")]
        public string KursName { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public DateTime Vaqt { get; set; }
    }
}
