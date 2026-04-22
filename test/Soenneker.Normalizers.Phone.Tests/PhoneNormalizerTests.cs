using Soenneker.Normalizers.Phone.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
