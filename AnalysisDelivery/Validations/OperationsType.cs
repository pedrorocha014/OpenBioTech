using AnalysisDelivery.Helpers;
using AnalysisDelivery.Models;
using System.ComponentModel.DataAnnotations;

namespace AnalysisDelivery.Validations
{
    public class OperationsType: ValidationAttribute
    {
        private const string DefaultErrorMessage = "One or more invalid operation.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValidOperation;

            OperationsDictionary.operationsType.TryGetValue(value.ToString().ToUpper(), out isValidOperation);

            if (isValidOperation)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ??
                                            DefaultErrorMessage);
            }
        }
    }
}
