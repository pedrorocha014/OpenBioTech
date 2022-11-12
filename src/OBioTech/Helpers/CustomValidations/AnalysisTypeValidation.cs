using OBioTech.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace OBioTech.Helpers.CustomValidations
{
    public class AnalysisTypeValidation: ValidationAttribute
    {
        private const string DefaultErrorMessage = "Invalid analysis.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValidOperation = Enum.IsDefined(typeof(AnalysisType), value.ToString().ToUpper());

            if (isValidOperation)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(DefaultErrorMessage);
            }
        }
    }
}
