using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding
{
    public class AgeCheckAttributes : ValidationAttribute
    {
        public int MinimumAge { get; private set; }
        public int MaximumAge { get; private set; }

        public AgeCheckAttributes(int min, int max)
        {
            MinimumAge = min;
            MaximumAge = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = Convert.ToDateTime(value);

            if (date.AddYears(MinimumAge) > DateTime.Today || date.AddYears(MaximumAge) < DateTime.Today)
            {
                Console.WriteLine(date.AddYears(MinimumAge));
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // 有帶 ErrorMessage 的話優先使用
            // [AgeCheck(18, 120, ErrorMessage="xxx")]
            if (!String.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }

            // 自訂錯誤訊息
            return $"{validationContext.DisplayName} can't be in future";
        }
    }
}
