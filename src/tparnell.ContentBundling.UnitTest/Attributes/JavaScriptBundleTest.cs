using NUnit.Framework;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.UnitTest.Attributes
{
    [TestFixture]
    public class JavaScriptBundleTest
    {
        [Test]
        public void CreateJavaScriptBundleAttribute()
        {
            var td = new JavaScriptBundleAttribute("test bundle", "~/d",AsyncLoading.Async, "/");
        }
    }
}
