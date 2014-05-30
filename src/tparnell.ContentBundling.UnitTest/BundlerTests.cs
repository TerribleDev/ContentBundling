using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;
using tparnell.ContentBundling.Exceptions;

namespace tparnell.ContentBundling.UnitTest
{
    [TestFixture]
    [JavaScriptBundle("awesome", "/", AsyncLoading.Async,"/")]
    public class BundlerTests
    {
        [TearDown]
        public void Teardown()
        {
            Bundler.BundleFactory = null;
            
        }
        [Test]
        [ExpectedException(typeof(NoBundleFactoryException))]
        public void ConfirmThrownException()
        {

            var td = new Bundler(false);

            try
            {
                var ts = Task.Run(() => td.Bundle());
                ts.Wait();
            }
            catch (AggregateException e)
            {

                throw e.InnerException;
            }


        }
        [Test]
        public void ConfirmBundleCollectionCreation()
        {

            var td = new Bundler(false);
            Assert.IsNotNull(Bundler.BundlesCreated);
        }

        [Test]
        public void MakeSureBundlesCreatedIsNotNull()
        {

            if(Bundler.BundlesCreated == null) Assert.Fail();
        }
        [Test]
        public void SetPath()
        {
            var path = "awesomepath";
            var td = new Bundler(false).SetPath(path);
            Assert.IsTrue(string.Equals(path, Bundler.RootPath));

        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassNullFactory()
        {

            var td = new Bundler(null,true);
            
        }
        [Test]
        public void ConfirmOverriddenFactory()
        {
            var refer = new Mock<IBundlesFactory>().Object;
            var td = new Bundler(new Mock<IBundlesFactory>().Object, false);
            var ts = new Bundler(refer, true);
            Assert.IsTrue(refer == Bundler.BundleFactory);

        }
        [Test]
        public void ConfirmOverriddenFactoryFailed()
        {
            var refer = new Mock<IBundlesFactory>().Object;
            var td = new Bundler(new Mock<IBundlesFactory>().Object, false);
            var ts = new Bundler(refer, false);
            Assert.IsFalse(refer == Bundler.BundleFactory);

        }
        [Test]
        public void ConfirmFactoryIsNotOverridentFromAssembly()
        {
            var refer = new Mock<IBundlesFactory>().Object;
            var ts = new Bundler(refer, true);
            var td = new Bundler(true);
            Assert.IsTrue(refer == Bundler.BundleFactory);

        }

        [Test]
        public void BundleIt()
        {
            var refer = new Mock<IBundlesFactory>();
            refer.Setup(x => x.BundleContent(It.IsAny<IBundleAttribute>(), It.IsAny<bool>()));
            var ts = new Bundler(refer.Object);
            var tsk = Task.Run(()=>ts.BundleAsync());
            tsk.Wait();
            refer.Verify();

        }


        [Test]
        public void ForceDebug()
        {
            new Bundler(new Mock<IBundlesFactory>().Object, true);
            var ts = Task.Run(async () => { await new Bundler().ForceDebugAsync(); });
            ts.Wait();
            Assert.IsTrue(Bundler.IsForceDebug);
            var bs = Task.Run(async () => { await new Bundler().ClearForceDebugAsync(); });
            bs.Wait();

        }
        [Test]
        public void ClearDebug()
        {
            new Bundler(new Mock<IBundlesFactory>().Object, true);
            var td = Task.Run(async () => { await new Bundler().ClearForceDebugAsync(); });
            td.Wait();
            Assert.IsTrue(!Bundler.IsForceDebug );
        }
    }
}
