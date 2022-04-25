namespace Forge.Domain.Entities;

using Forge.Domain.Types;

public sealed class BookEntity
{
    public string Title { get; set; } = string.Empty;
    public Ean Ean { get; set; } = default!;
}
