using System;
using System.Collections.Concurrent;
using System.Linq;
using tparnell.ContentBundling.Attributes;
using tparnell.ContentBundling.Exceptions;

namespace tparnell.ContentBundling
{
    public partial  class Bundler
    {
        public static bool IsForceDebug { get; private set; }
        public static ConcurrentBag<string> BundlesCreated { get; private set; }
        public static string RootPath { get; set; }
        public static IBundlesFactory BundleFactory { get; set; }
        //empty constructor so we allways have a constructor that is paramterless
        public Bundler(bool loadFactoryFromAssembly = true, bool overrideExisting = false)
        {
            if (BundleFactory != null && !overrideExisting) return;
            if (loadFactoryFromAssembly) ForceFactoryReloadFromAssembly();
        }
        public Bundler(IBundlesFactory factory, bool replaceExisting = true)
        {
            if(factory == null) throw new ArgumentNullException("factory");
            if (BundleFactory != null && !replaceExisting) return;
            BundleFactory = factory;
        }


        static Bundler()
        {
            if (BundlesCreated == null) BundlesCreated = new ConcurrentBag<string>();

        }

        public void ForceFactoryReloadFromAssembly()
        {
            var assems = AppDomain.CurrentDomain.GetAssemblies();
            var types = assems.SelectMany(s => s.GetTypes()).FirstOrDefault(p => typeof(IBundlesFactory).IsAssignableFrom(p) && p.IsClass && !p.IsInterface);
            if (types == null) throw new TypeAccessException();
            //lame excuse for dependancy injection, but for now it works
            BundleFactory = (IBundlesFactory)Activator.CreateInstance(types);
        
        }

        public Bundler Bundle()
        {
            if (BundleFactory == null) throw new NoBundleFactoryException();
            var assems = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.GetReferencedAssemblies().Any(r => r.Name.StartsWith("tparnell.ContentBundling", StringComparison.OrdinalIgnoreCase)));
            //boy do I hate myself for doing this....Basically scan through loaded assemblies looking for bundles that should be built on app startup
           assems.AsParallel().ForAll(x => x.GetTypes().ToList().Where(ds => (ds.GetCustomAttributes(typeof(IBundleAttribute), true)).Any()).AsParallel().ForAll(
               dx =>
               {
                   Environment.CurrentDirectory = string.IsNullOrEmpty(RootPath) ? Environment.CurrentDirectory : RootPath;
                   var bundles = dx.GetCustomAttributes(typeof(IBundleAttribute), true).Select(a => (IBundleAttribute)a);
                   foreach (var bund in bundles)
                   {
                       var bundlename = bund != null ? bund.BundleName : "Unknown Bundle";
                       BundlesCreated.Add(bundlename);
                       BundleFactory.BundleContent(bund, IsForceDebug);
                   }
               }));
            return this;
        }

        #region RepositoryThings

        public Bundler SetPath(string path)
        {
            RootPath = path;
            return this;
        }

        /// <summary>
        /// Force Debug
        /// </summary>
        /// <returns>Self</returns>
        public Bundler ForceDebug()
        {
            IsForceDebug = true;
            PurgeBundles();
            return Bundle();
        }
        /// <summary>
        /// Clear force debug
        /// </summary>
        /// <returns>self</returns>
        public Bundler ClearForceDebug()
        {
            IsForceDebug = false;
            PurgeBundles();
            return Bundle();
        }

        public Bundler PurgeBundles()
        {
            BundlesCreated = new ConcurrentBag<string>();
            BundleFactory.RebuildCache();
            return this;
        }
        #endregion


    }
}