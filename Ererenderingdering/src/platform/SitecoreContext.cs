using Sitecore;
using Sitecore.Data;

namespace Ererenderingdering.Foundation.VariantJsx
{
    public class SitecoreContext : ISitecoreContext
    {
        public Database GetContextDatabase()
        {
            return Context.Database;
        }
    }
}