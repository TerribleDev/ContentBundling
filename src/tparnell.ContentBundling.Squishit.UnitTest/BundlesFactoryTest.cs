using System;
using NUnit.Framework;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;
using tparnell.ContentBundling.Squishit;

namespace EventManager.Web.UnitTests.Bundles
{
    [TestFixture]
    public class BundlesFactoryTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNull()
        {
            new BundlesFactory().BundleContent(null);

        }
        [Test]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void TestBadFilePath()
        {
            new BundlesFactory().BundleContent(new JavaScriptBundleAttribute("absurd content", "/", AsyncLoading.Async, "/Iamawesome.txt"));

        }
        [Test]
        public void ClearPreProcessors()
        {
            new BundlesFactory().RebuildCache();
            
        }
    }
}
