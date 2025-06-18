using FluentValidation.Results;

namespace Woody230.FluentValidation.Results;

/// <summary>
/// Represents extensions for the <see cref="ValidationResult"/> class.
/// </summary>
public static class ValidationResultExtensions
{
    /// <summary>
    /// Combines the error messages into a single error message.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The error message.</returns>
    public static string GetErrorMessage(this ValidationResult result)
    {
        static string Message(ValidationFailure failure) => $"[{failure.PropertyName}] {failure.ErrorMessage}";
        var messages = result.Errors.Select(Message);
        return string.Join(Environment.NewLine, messages); 
    }

    /// <summary>
    /// Flattens multiple results into a single result with all of the failures combined.
    /// </summary>
    /// <param name="results">The results.</param>
    /// <returns>The result.</returns>
    public static ValidationResult Flatten(this IEnumerable<ValidationResult> results)
    {
        return new ValidationResult(results.SelectMany(result => result.Errors));
    }
}
