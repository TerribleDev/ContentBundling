using System;
using SquishIt.Framework;
using SquishIt.Framework.CSS;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Enum;

namespace tparnell.ContentBundling.Squishit
{
    public sealed class BundlesFactory : IBundlesFactory
    {
        /// <summary>
        /// Bundles Javascript
        /// </summary>
        /// <param name="bundle">Bundle Attribute</param>
        /// <param name="debug">Debug Flag</param>
        private static void BundleJs(IBundleAttribute bundle, bool debug)
        {
                BundlesProcessor.StandardProcess<SquishIt.Framework.JavaScript.JavaScriptBundle>( bundle, debug, fd =>
                {
                    //Add the defer or async attribute to html tags if the attribute wants to go async
                    switch (bundle.Async)
                    {
                        case AsyncLoading.Defer:
                            fd.WithAttribute("defer", string.Empty);
                            break;
                        case AsyncLoading.Default:
                            fd.WithAttribute("defer", string.Empty);
                            break;
                        case AsyncLoading.Async:
                            fd.WithAttribute("async", string.Empty);
                            break;
                    }
                    return fd;
                });
                
            
        }
        /// <summary>
        /// Bundles CSS
        /// </summary>
        /// <param name="bundle">Bundle attribute</param>
        /// <param name="debug">debug flag</param>
        private static void BundleCss(IBundleAttribute bundle, bool debug)
        {
          BundlesProcessor.StandardProcess<CSSBundle>( bundle, debug, cssBundle => cssBundle);
            
        }

        public void BundleContent(IBundleAttribute bundle, bool debug = false)
        {
            if (bundle == null) throw new ArgumentNullException("bundle");
                if (bundle.Contenttype == ContentType.JavaScript) BundleJs(bundle, debug);
                if (bundle.Contenttype == ContentType.Css) BundleCss(bundle, debug);
            
        }


        public void RebuildCache()
        {
            Bundle.ClearPreprocessors();
        }
    }
}