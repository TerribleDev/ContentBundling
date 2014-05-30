using System;
using NUnit.Framework;
using SquishIt.Framework.JavaScript;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Squishit.UnitTest
{
    [TestFixture]
   public class BundlessProcessorTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullBundle()
        {
            BundlesProcessor.StandardProcess<SquishIt.Framework.CSS.CSSBundle>(null, false, null);
        }
        [Test]
        public void PassCssBundle()
        {
            BundlesProcessor.StandardProcess<SquishIt.Framework.CSS.CSSBundle>(new CssBundleAttribute("ts", "/ds","./"), false, null);
        }
        [Test]
        public void PassJsBundle()
        {
            BundlesProcessor.StandardProcess<JavaScriptBundle>(new JavaScriptBundleAttribute("ts", "/ds", AsyncLoading.Default ,"./"), false, null);
        }
        [Test]
        public void ConfirmInvokationOfunctionBundle()
        {
            BundlesProcessor.StandardProcess<JavaScriptBundle>(new JavaScriptBundleAttribute("ts", "/ds", AsyncLoading.Default, "./"), false, (d)=>
            {
                Assert.Pass();
                return d;
            });

            Assert.Fail();
        }
    }
}
