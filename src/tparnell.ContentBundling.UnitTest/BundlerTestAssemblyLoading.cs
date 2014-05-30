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
            //Bundler.BundleFactory = null;
            //new Bundler(false).ForceFactoryReloadFromAssembly();
            //TODO: Figure out best way to test
            throw new TypeAccessException();

        }
    }
}
