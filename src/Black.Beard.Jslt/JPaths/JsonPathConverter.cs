using Bb.Json;
using System;

namespace Bb.JPaths;

/// <summary>
/// JSON converter for <see cref="JsonPath"/>.
/// </summary>
public class JsonPathConverter : JsonConverter<JsonPath>
{


    public override JsonPath? ReadJson(JsonReader reader, Type objectType, JsonPath? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var text = reader.ReadAsString()!;
        return JsonPath.Parse(text);
    }

    public override void WriteJson(JsonWriter writer, JsonPath? value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}
