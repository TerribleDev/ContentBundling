using System;
using System.Linq;
using NUnit.Framework;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.UnitTest.Attributes
{
    [TestFixture]
    public class BaseAttribute
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void ConfirmEmptyBundleName()
        {
            var ts = new DefaultBundleAttribute("", "tst", ContentType.JavaScript, AsyncLoading.Async, "dsds");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void ConfirmNullBundleName()
        {
            var ts = new DefaultBundleAttribute(null, "tst", ContentType.JavaScript, AsyncLoading.Async, "dsds");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void ConfirmEmptyOutputURI()
        {
            var ts = new DefaultBundleAttribute("tst", "", ContentType.JavaScript, AsyncLoading.Async, "dsds");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void ConfirmNullOutputURI()
        {
            var ts = new DefaultBundleAttribute("tst", null, ContentType.JavaScript, AsyncLoading.Async, "dsds");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public static void ConfirmEmptyFilePath()
        {
            var ts = new DefaultBundleAttribute("tst", "ds", ContentType.JavaScript, AsyncLoading.Async, new string[]{});
        }
        [Test]
        public static void ConfirmBundleNameApplied()
        {
            var td = "tst";
            var ts = new DefaultBundleAttribute(td, "ds", ContentType.JavaScript, AsyncLoading.Async, new string[] { "tst"});
            Assert.IsTrue(string.Equals(ts.BundleName,td));
        }
        [Test]
        public static void ConfirmBundleOutputURIApplied()
        {
            var td = "tst";
            var ts = new DefaultBundleAttribute("TST", td, ContentType.JavaScript, AsyncLoading.Async, new string[] { "tst" });
            Assert.IsTrue(string.Equals(ts.OutputUri, td));
        }
        [Test]
        public static void ConfirmBundleFileURIApplied()
        {
            var td = "tst";
            var ts = new DefaultBundleAttribute("TST", "TDS", ContentType.JavaScript, AsyncLoading.Async, new[] { td });
            Assert.IsTrue(string.Equals(ts.Fileuri.FirstOrDefault(), td));
        }
    }
}
