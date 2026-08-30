using Soenneker.Normalizers.Phone.Abstract;
using Soenneker.Tests.HostedUnit;
using AwesomeAssertions;

namespace Soenneker.Normalizers.Phone.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class PhoneNormalizerTests : HostedUnitTest
{
    private readonly IPhoneNormalizer _util;

    public PhoneNormalizerTests(Host host) : base(host)
    {
        _util = Resolve<IPhoneNormalizer>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    [Arguments("(412) 555-0100", "+14125550100")]
    [Arguments("1-412-555-0100", "+14125550100")]
    [Arguments(" +44 20 7946 0958", "+442079460958")]
    [Arguments("011 44 20 7946 0958", "+442079460958")]
    [Arguments("00 44 20 7946 0958", "+442079460958")]
    public void Normalizes_supported_dialing_forms(string input, string expected)
    {
        _util.Normalize(input).Should().Be(expected);
    }

    [Test]
    [Arguments("+00 44 20 7946 0958")]
    [Arguments("44 20 7946 0958")]
    [Arguments("12345")]
    [Arguments(null)]
    public void Rejects_unsupported_or_invalid_forms(string? input)
    {
        _util.Normalize(input).Should().BeNull();
    }
}
