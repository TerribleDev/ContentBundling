using NUnit.Framework;
using tparnell.ContentBundling.Exceptions;

namespace tparnell.ContentBundling.UnitTest.Exception
{
    [TestFixture]
    public class NoBundleFactoryExceptionTest
    {
        [Test]
        [ExpectedException(typeof(NoBundleFactoryException))]
        public void CallException()
        {
            throw new NoBundleFactoryException();
        }

        [Test]
        [ExpectedException(typeof(NoBundleFactoryException))]
        public void CallExceptionWithMessage()
        {
            throw new NoBundleFactoryException("Test Message");
        }

        [Test]
        [ExpectedException(typeof(NoBundleFactoryException))]
        public void CallExceptionWithMessageAndInnerException()
        {
            throw new NoBundleFactoryException("Test Message", new NoBundleFactoryException());
        }
    }
}
