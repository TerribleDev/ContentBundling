using System;
using SquishIt.Framework;
using SquishIt.Framework.Base;
using tparnell.ContentBundling.Attributes;

namespace tparnell.ContentBundling.Squishit
{
    internal sealed class BundlesProcessor
    {
        /// <summary>
        /// This is where the bundling actually happens
        /// </summary>
        /// <typeparam name="T">T is the the type of squishit class to use </typeparam>
        /// <param name="bundle">A bundle attribute</param>
        /// <param name="debug">debug flag</param>
        /// <param name="d">preprocessing</param>
        internal static void StandardProcess<T>(IBundleAttribute bundle, bool debug, Func<T, T> d) where T:BundleBase<T>
        {
            if(bundle == null) throw  new ArgumentNullException("bundle");
            //Get the type of T
            var tType = typeof (T);
            //declare ds variable (this will be our bundler)
            dynamic ds = null;
            //if T is Javascript bundle make our bundler be the javascript bundler
            if (tType == typeof (SquishIt.Framework.JavaScript.JavaScriptBundle))
            {
                ds = Bundle.JavaScript();
               
            }
            //if T is css make our bundler be the javascript bundler
            else if (tType == typeof (SquishIt.Framework.CSS.CSSBundle))
            {
                ds = Bundle.Css();
            }
            //if our bundler is still null then we should throw a not supported exception
            if(ds == null) throw new NotSupportedException();
            //if our function is not null then we should invoke it
            if(d != null)ds = d.Invoke((T)ds);
            //Add a bunch of files
            foreach (var x in bundle.Fileuri)
            {
                ds.Add(x);
            }
            //declare a func for our debug flag to use
            Func<bool> z = () => { return debug; };
            ds.ForceDebugIf(z);
            ds.AsCached(bundle.BundleName, bundle.OutputUri);
        }
        
    }
}