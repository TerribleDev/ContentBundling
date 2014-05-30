using System.Collections.Generic;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Attributes
{
    public interface IBundleAttribute
    {
        string BundleName { get; }
        string OutputUri { get; }
        ContentType Contenttype { get;  }
        IEnumerable<string> Fileuri { get; }
        AsyncLoading Async { get; }
    }
}