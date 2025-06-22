![](https://img.shields.io/github/license/Woody230/CSharpExtensions)
[![](https://img.shields.io/nuget/v/Woody230.Text.Json.Converters)](https://www.nuget.org/packages/Woody230.Text.Json.Converters)

# Text.Json.Converters

Custom [JsonConverters](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonconverter) for the System.Text.Json namespace.

## JsonConverters

| Type | Name | Description |
| --- | --- | --- |
| Regex | CompiledRegexJsonConverter | Converts a string to and from Regex using the compiled option. |
| Regex | RegexJsonConverter | Converts a string to and from Regex without options. |
| Uri | AbsoluteUriJsonConverter | Converts a string to and from a Uri that is absolute. |
| Uri | RelativeUriJsonConverter | Converts a string to and from a Uri that is relative. |
| Uri | RelativeOrAbsoluteUriJsonConverter | Converts a string to and from a Uri that is relative or absolute. |