using System;
using System.ComponentModel.DataAnnotations;

namespace IctBukhara.uz.Entitys
{
    public class TelRangeAttribute : ValidationAttribute
    {
        private readonly long _min;
        private readonly long _max;
        public TelRangeAttribute(long min = 100000000, long max = 999999999)
        {
            _max = max;
            _min = min;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var val = value as long?;
                if (val is not null)
                {
                    if (val < _min || val > _max)
                        throw new Exception($"Tel raqam 9 xonali bo'lishi shart!");
                }
                return ValidationResult.Success;

            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }

        }
    }
}
