using BindableEnum.Library.Models;
using System.ComponentModel.DataAnnotations;

namespace BindableEnum.Library.Validation
{
    /// <summary>
    /// Validates that a bindable enum has been successfully binded.
    /// </summary>
    public class BindableEnumAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is not IBindableEnum @enum)
            {
                return new ValidationResult("Expected the enum to be bindable.");
            }

            if (!@enum.Binded)
            {
                var expectedValues = string.Join(", ", @enum.Values);
                return new ValidationResult($"Value `{@enum}` must be one of: {expectedValues}");
            }

            return ValidationResult.Success;
        }
    }
}
