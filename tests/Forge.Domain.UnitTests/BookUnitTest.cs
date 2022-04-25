namespace Forge.Domain.UnitTests;

using Forge.Domain.Entities;
using Forge.Domain.Types;
using System.Text.Json;

[TestClass]
public sealed class BookUnitTest
{
    private const long EAN = 9780735611311;
    private const string TITLE = "CODE, The Hidden Language of Computer Hardware and Software";

    public TestContext TestContext { get; set; } = default!;
    private readonly JsonSerializerOptions options = new();

    [TestMethod]
    public void TestMethod1()
    {
        var result = new BookEntity
        {
            Title = TITLE,
            Ean = new Ean(EAN),
        };

        result.Should().NotBeNull();
    }

    [TestMethod]
    public void TestMethod2()
    {
        var source = new BookEntity
        {
            Title = TITLE,
            Ean = new Ean(EAN),
        };

        var result = JsonSerializer.Serialize(source, this.options);

        TestContext.WriteLine(result);

        result.Should().NotBeNull();
        result.Length.Should().BeGreaterThan(0);
        result.Should().Contain(TITLE);
        result.Should().Contain($"{EAN}");
        result.Should().NotContain($"\"{EAN}\"");
    }

    [TestMethod]
    public void TestMethod3()
    {
        var source = new BookEntity
        {
            Title = TITLE,
            Ean = new Ean(EAN),
        };

        var jsonString = JsonSerializer.Serialize(source, this.options);

        var result = JsonSerializer.Deserialize<BookEntity>(jsonString, this.options);

        result.Should().NotBeNull();
        result!.Ean.Value.Should().Be(EAN);
        result!.Title.Should().Be(TITLE);
    }
}
