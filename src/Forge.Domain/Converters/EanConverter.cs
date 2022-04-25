namespace Forge.Domain.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;
using Forge.Domain.Types;

public sealed class EanConverter : JsonConverter<Ean>
{
    public override Ean Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new Ean(reader.GetInt64());
    }

    public override void Write(Utf8JsonWriter writer, Ean value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
