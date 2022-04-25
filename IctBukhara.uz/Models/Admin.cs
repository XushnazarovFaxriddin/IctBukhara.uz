using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IctBukhara.uz.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Login bo'sh bo'lishi mumkin emas!"),
            MinLength(4, ErrorMessage = "Login kamida 4 ta belgidan iborat bo'lishi kerak!"),
            MaxLength(32, ErrorMessage = "Login ko'pi bilan 32 ta belgidan iborat bo'lishi kerak!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Parol bo'sh bo'lishi mumkin emas!"),
            MinLength(4, ErrorMessage = "Parol kamida 4 ta belgidan iborat bo'lishi kerak!"),
            MaxLength(72, ErrorMessage = "Parol ko'pi bilan 72 ta belgidan iborat bo'lishi kerak!"),
            JsonIgnore]
        public string Password { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
