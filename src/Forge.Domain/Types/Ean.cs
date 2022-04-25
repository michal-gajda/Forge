namespace Forge.Domain.Types;

using Forge.Domain.Converters;
using System.Text.Json.Serialization;

[JsonConverter(typeof(EanConverter))]
public sealed class Ean : StronglyTypedValue<long>
{
    public Ean(long value) : base(value)
    {
        var ean = $"{value}";

        if (ean.Length != 13)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
