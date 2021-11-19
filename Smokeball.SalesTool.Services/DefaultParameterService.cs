using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;

namespace Smokeball.SalesTool.Services
{
    /// <summary>
    /// Responsible for Default parameters for Search
    /// </summary>
    public class DefaultParameterService : IDefaultParameterService
    {
        private const string DefaultSearchUrl = @"https://www.google.com.au/search?num=100&q=conveyancing+software";
        private const string DefaultSearcKeyWord = @"smokeball.com.au";
        private const string SearchPattern = "<div class=\"BNeawe UPmit AP7Wnd\">(.*?)</div>";
        public SearchRelevanceInput GetDefaultInput()
        {
            return new SearchRelevanceInput() { SearchUrl = DefaultSearchUrl, SearchKeyWord= DefaultSearcKeyWord, SearchPattern=SearchPattern};
        }
    }
}
