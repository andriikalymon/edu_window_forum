using System;
using System.Linq;

namespace Forum.Web.Utils
{
    public static class SearchService
    {
        public static bool Match(string searchCriteria, params string[] searchSource)
            => searchSource.Any(s => s.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase));
    }
}
