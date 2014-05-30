using NUnit.Framework;
using tparnell.ContentBundling.Attributes;

namespace tparnell.ContentBundling.UnitTest.Attributes
{
    [TestFixture]
   public class CssBundleTest
    {
        [Test]
        public void CreateCssBundle()
        {
            var td = new CssBundleAttribute("test bundle", "~/d", "/");
        }
    }
}
