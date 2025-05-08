using Soenneker.Normalizers.Phone.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Normalizers.Phone.Tests;

[Collection("Collection")]
public class PhoneNormalizerTests : FixturedUnitTest
{
    private readonly IPhoneNormalizer _util;

    public PhoneNormalizerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IPhoneNormalizer>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
