using tparnell.ContentBundling.Attributes;

namespace tparnell.ContentBundling
{
    public interface IBundlesFactory
    {
        void BundleContent(IBundleAttribute bundle, bool debug = false);
        void RebuildCache();
    }
}
