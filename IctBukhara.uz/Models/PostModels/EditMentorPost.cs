using IctBukhara.uz.Entitys;
using IctBukhara.uz.Entitys.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace IctBukhara.uz.Models.PostModels
{
    public class EditMentorPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ism Familiya bo'sh bo'lishi mumkin emas!"),
            MaxLength(60), MinLength(5), DisplayName("Mentor ism familyasi")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mentor haqida bo'sh bo'lishi mumkin emas!"),
            MaxLength(200), MinLength(10), DisplayName("Mentor haqida")]
        public string Discription { get; set; }

        [NotNull, Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!"),
            DisplayName("CV turi")]
        public CV Cv { get; set; }

        [DisplayName("Mentor rasmi"),
            MaxFileSize(5 * 1024 * 1024), AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Bo'sh bo'lishi mumkin emas!")]
        public string CvUrl { get; set; }
    }
}
