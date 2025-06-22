namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests for a <see cref="RelativeUriJsonConverter"/>
/// </summary>
public class RelativeUriJsonConverterTests : BaseUriJsonConverterTests<RelativeUriJsonConverter>
{
    protected override UriKind UriKind { get; } = UriKind.Relative;
    protected override string Uri { get; } = "portal/home";
}
