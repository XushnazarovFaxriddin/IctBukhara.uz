﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IctBukhara.uz.Entitys
{
    /// <summary>
    /// File hajmini validatsiya qilish (bytelarda)
    /// </summary>
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Kechirasiz {_maxFileSize} bytedan katta file yuklash mumkin emas!";
        }
    }
}
