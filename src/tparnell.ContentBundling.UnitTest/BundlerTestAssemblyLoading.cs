using System;
using NUnit.Framework;

namespace tparnell.ContentBundling.UnitTest
{
    [TestFixture]
    public class BundlerTestAssemblyLoading
    {
        [Test]
        [ExpectedException(typeof(TypeAccessException))]
        public void LoadFromAssembly()
        {
            new Bundler(false).ForceFactoryReloadFromAssembly();

        }
    }
}
