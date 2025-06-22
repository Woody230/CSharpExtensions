namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests for a <see cref="AbsoluteUriJsonConverter"/>
/// </summary>
public class AbsoluteUriJsonConverterTests : BaseUriJsonConverterTests<AbsoluteUriJsonConverter>
{
    protected override UriKind UriKind { get; } = UriKind.Absolute;
    protected override string Uri { get; } = "https://www.google.com";
}
