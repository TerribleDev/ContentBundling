using System;
using System.Collections.Generic;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DefaultBundleAttribute:  Attribute, IBundleAttribute
    {
        public string BundleName { get; private set; }
        public string OutputUri { get; private set; }
        public ContentType Contenttype { get; private set; }
        public IEnumerable<string> Fileuri { get; private set; }
        public AsyncLoading Async { get; private set; }

        public DefaultBundleAttribute(string bundleName, string outputUri, ContentType contenttype, AsyncLoading async, params string[] fileuri)
        {
            if(String.IsNullOrWhiteSpace(bundleName)) throw new ArgumentNullException("bundleName");
            if (String.IsNullOrWhiteSpace(outputUri)) throw new ArgumentNullException("outputUri");
            if (fileuri.Length < 1) throw new ArgumentNullException("fileuri");
            BundleName = bundleName;
            OutputUri = outputUri;
            Contenttype = contenttype;
            Fileuri = fileuri;
            Async = async;
        }
    }

}