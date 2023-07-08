using FluentValidation;
using Woody230.FluentValidation.Resources;

namespace Woody230.FluentValidation.Validators.Property
{
    /// <summary>
    /// Validates that the <typeparamref name="TProperty"/> is not a null or default value.
    /// </summary>
    /// <typeparam name="T">The type of model.</typeparam>
    /// <typeparam name="TProperty">The type of property.</typeparam>
    public sealed class DefaultPropertyValidator<T, TProperty> : ExtensiblePropertyValidator<T, TProperty>
    {
        /// <summary>
        /// Validates that the <typeparamref name="TProperty"/> is not a null or default value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="value">The value.</param>
        /// <returns>False if null or a default value, otherwise true.</returns>
        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            return value != null && !value.Equals(default(TProperty));
        }

        /// <inheritdoc/>
        protected override ErrorMessageTemplateBuilder BuildDefaultErrorMessage(string errorCode)
        {
            return "must not be null or defaulted";
        }
    }
}
