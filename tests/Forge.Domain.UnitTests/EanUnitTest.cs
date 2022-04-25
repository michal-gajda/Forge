namespace Forge.Domain.UnitTests;

using Forge.Domain.Types;

[TestClass]
public sealed class EanUnitTest
{
    private const long EAN = 9780735611311;

    [TestMethod]
    public void TestMethod4()
    {
        var result = new Ean(EAN);
        result.Value.Should().Be(EAN);
    }

    [TestMethod]
    public void TestMethod5()
    {
        Action result = () => new Ean(default);
        result.Should().Throw<ArgumentOutOfRangeException>();
    }
}
