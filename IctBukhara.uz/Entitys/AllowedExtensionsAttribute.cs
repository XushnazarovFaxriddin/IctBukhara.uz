using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace IctBukhara.uz.Entitys
{
    /// <summary>
    /// File formatini validatsiya qilish uchun.
    /// </summary>
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly IEnumerable<string> _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions.Select(x => x.ToLower());
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return @$"Iltimos faqat ""{string.Join(@""", """, _extensions)}"" formatlarda rasm yuklang!";
        }
    }
}
