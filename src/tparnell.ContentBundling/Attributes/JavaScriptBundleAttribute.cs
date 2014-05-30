using System;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class JavaScriptBundleAttribute : DefaultBundleAttribute
    {
        public JavaScriptBundleAttribute(string bundleName, string outputUri, AsyncLoading async  , params string[] fileuri)
            : base(bundleName, outputUri, ContentType.JavaScript, async, fileuri)
        {
        }
    }
}