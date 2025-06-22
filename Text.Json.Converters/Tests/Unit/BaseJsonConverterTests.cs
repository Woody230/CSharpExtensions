using System.Text.Json;
using System.Text.Json.Serialization;

namespace Woody230.Text.Json.Converters.Tests.Unit;

/// <summary>
/// Represents tests related to a <see cref="JsonConverter"/>
/// </summary>
public abstract class BaseJsonConverterTests
{
    protected JsonSerializerOptions SerializerOptions { get; } = new() { WriteIndented = true };
}
