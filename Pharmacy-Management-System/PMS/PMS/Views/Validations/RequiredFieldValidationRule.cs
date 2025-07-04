using System.Globalization;
using System.Windows.Controls;

namespace PMS.Views.Validations
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(false, "This field is required.");
            return ValidationResult.ValidResult;
        }
    }
}