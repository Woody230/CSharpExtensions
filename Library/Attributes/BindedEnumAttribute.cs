using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Woody230.BindableEnum.Models;

namespace Woody230.BindableEnum.Attributes
{
    /// <summary>
    /// Validates that a bindable enum has been successfully binded.
    /// </summary>
    public class BindedEnumAttribute : ValidationAttribute
    {
        /// <summary>
        /// <para>Validates that the bindable enum has been binded.</para>
        /// <para>
        /// A null value is considered valid. 
        /// If nulls should not be allowed, then the <see cref="RequiredAttribute"/> should also be applied.
        /// </para>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A success result if the bindable enum has been binded OR the value is null.</returns>
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
                var expectedValues = @enum.Enum.GetType().GetEnumValues().Cast<Enum>().Select(@enum => @enum.ToString());
                return new ValidationResult($"Value `{@enum}` must be one of: {string.Join(", ", expectedValues)}");
            }

            return ValidationResult.Success;
        }
    }
}
