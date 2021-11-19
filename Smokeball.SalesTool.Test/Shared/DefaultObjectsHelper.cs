using Smokeball.SalesTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Test.Shared
{
    internal class DefaultObjectsHelper
    {

        const string DefaultSearchUrl = @"https://www.google.com.au/search?num=100&q=conveyancing+software";
        const string DefaultSearcKeyWord = @"smokeball.com.au";
        const string SearchPattern = "<div class=\"BNeawe UPmit AP7Wnd\">(.*?)</div>";

        public static SearchRelevanceInput GetSearchRelevanceInput()
        {
            var searchRelevanceInput = new SearchRelevanceInput() { SearchKeyWord = DefaultSearcKeyWord, SearchPattern = SearchPattern, SearchUrl = DefaultSearchUrl };
            return searchRelevanceInput;
        }
    }
}
