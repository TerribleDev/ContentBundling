using System.Threading.Tasks;

namespace tparnell.ContentBundling
{
    public partial class Bundler
    {

        public async Task<Bundler> BundleAsync()
        {
            return await Task.Run(() => Bundle());
        }

        /// <summary>
        /// Force Debug
        /// </summary>
        /// <returns>Self</returns>
        public async Task<Bundler> ForceDebugAsync()
        {
            return await Task.Run(() => ForceDebug());
        }
        /// <summary>
        /// Clear force debug
        /// </summary>
        /// <returns>self</returns>
        public async Task<Bundler> ClearForceDebugAsync()
        {
            return await Task.Run(() => ClearForceDebug());
        }

    }
}