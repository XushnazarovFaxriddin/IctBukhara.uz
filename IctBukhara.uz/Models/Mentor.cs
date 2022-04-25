using IctBukhara.uz.Entitys.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace IctBukhara.uz.Models
{
    public class Mentor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ism Familiya bo'sh bo'lishi mumkin emas!"),
            MaxLength(60), MinLength(5)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mentor haqida bo'sh bo'lishi mumkin emas!"),
            MaxLength(200), MinLength(10)]
        public string Discription { get; set; }

        [NotNull, Required]
        public CV Cv { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string CvUrl { get; set; }
    }
}
