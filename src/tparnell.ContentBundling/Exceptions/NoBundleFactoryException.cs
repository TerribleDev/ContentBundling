using System;

namespace tparnell.ContentBundling.Exceptions
{
    [Serializable]
   public sealed class NoBundleFactoryException : Exception
    {
            public NoBundleFactoryException()
            :base("No Bundle Factory Loaded"){}


        public NoBundleFactoryException(string message):base(message){}

        public NoBundleFactoryException(string message, Exception innerException)
            :base(message,innerException){}
    }
}
