using Sitecore;
using Sitecore.Data;

namespace Ererenderingdering
{
    public class SitecoreContext : ISitecoreContext
    {
        public Database GetContextDatabase()
        {
            return Context.Database;
        }
    }
}