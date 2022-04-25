using IctBukhara.uz.Entitys;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IctBukhara.uz.Models.PostModels
{
    public class EditKursPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Kurs nomi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(10, ErrorMessage = "Kamida 10 ta belgi kiriting!"),
            MaxLength(300, ErrorMessage = "Ko'pi bilan 300 ta belgi kiriting!"),
            DisplayName("Kurs haqida")]
        public string Discription { get; set; }

        [DisplayName("Kurs Rasmi"), MaxFileSize(5 * 1024 * 1024), AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(3, ErrorMessage = "Kamida 3 ta belgi kiriting!"),
            MaxLength(30, ErrorMessage = "Ko'pi bilan 30 ta belgi kiriting!"),
            DisplayName("Kurs davomiyligi")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            MinLength(10, ErrorMessage = "Kamida 10 ta belgi kiriting!"),
            DisplayName("Kurs davomida o'rganiladi")]
        public string Learning { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"), NotNull]
        public int MentorId { get; set; }
    }
}
