namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests for a <see cref="RelativeOrAbsoluteUriJsonConverter"/>
/// </summary>
public class RelativeOrAbsoluteUriJsonConverterTests : BaseUriJsonConverterTests<RelativeOrAbsoluteUriJsonConverter>
{
    protected override UriKind UriKind { get; } = UriKind.RelativeOrAbsolute;
    protected override string Uri { get; } = "https://www.google.com";
}
