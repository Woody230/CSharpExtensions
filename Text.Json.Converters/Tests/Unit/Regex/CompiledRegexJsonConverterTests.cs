using System.Text.RegularExpressions;

namespace Woody230.Text.Json.Converters.Tests.Unit.Regex;

/// <summary>
/// Represents tests for the <see cref="CompiledRegexJsonConverter"/>
/// </summary>
public class CompiledRegexJsonConverterTests : BaseRegexJsonConverterTests<CompiledRegexJsonConverter>
{
    protected override RegexOptions RegexOptions { get; } = RegexOptions.Compiled;
}
