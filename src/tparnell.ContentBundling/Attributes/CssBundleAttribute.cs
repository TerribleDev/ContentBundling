using System;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CssBundleAttribute : DefaultBundleAttribute
    {
        public CssBundleAttribute(string bundleName, string outputUri, params string[] fileuri)
            : base(bundleName, outputUri, ContentType.Css, AsyncLoading.Default, fileuri)
        {
        }
    }
}