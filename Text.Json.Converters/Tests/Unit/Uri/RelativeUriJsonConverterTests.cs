namespace Woody230.Text.Json.Converters.Tests.Unit.Uri;

/// <summary>
/// Represents tests for a <see cref="RelativeUriJsonConverter"/>
/// </summary>
public class RelativeUriJsonConverterTests : BaseUriJsonConverterTests<RelativeUriJsonConverter>
{
    protected override UriKind UriKind { get; } = UriKind.Relative;

    public static Dictionary<string, bool> UriValidity { get; } = new Dictionary<string, bool>()
    {
        ["https://www.google.com"] = false,
        ["portal/home"] = true,
        ["https://stackoverflow.com/"] = false,
        [""] = true
    };

    [Theory]
    [MemberData(nameof(GetUrlValidityData))]
    public override void Read(string url, bool isValid)
    {
        ReadImpl(url, isValid);
    }

    protected override IDictionary<string, bool> GetUriValidity() => UriValidity;
    public static TheoryData<string, bool> GetUrlValidityData() => ToTheoryData(UriValidity);
}
