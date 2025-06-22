using System.Text.RegularExpressions;

namespace Woody230.Text.Json.Converters.Tests.Unit.Regex;

/// <summary>
/// Represents tests for the <see cref="RegexJsonConverter"/>
/// </summary>
public class RegexJsonConverterTests : BaseRegexJsonConverterTests<RegexJsonConverter>
{
    protected override RegexOptions RegexOptions => RegexOptions.None;
}
