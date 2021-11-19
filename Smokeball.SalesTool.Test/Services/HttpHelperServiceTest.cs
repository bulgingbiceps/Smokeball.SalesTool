using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.Services;
using Smokeball.SalesTool.Test.Shared;
using Xunit;

namespace Smokeball.SalesTool.Test.Services
{
    public class HttpHelperServiceTest
    {
        const string DefaultSearchUrl = @"https://www.google.com.au/search?num=100&q=conveyancing+software";
        const string DefaultSearcKeyWord = @"smokeball.com.au";
        const string SearchPattern = "<div class=\"BNeawe UPmit AP7Wnd\">(.*?)</div>";

        [Fact]
        public void TestGetSearchRelevance1()
        {
            var helperService = new HttpHelperService();
            //var searchRelevanceInput = new SearchRelevanceInput() { SearchKeyWord = DefaultSearcKeyWord, SearchPattern = SearchPattern, SearchUrl = DefaultSearchUrl };
            var searchRelevanceInput = DefaultObjectsHelper.GetSearchRelevanceInput();
            var response = helperService.GetHttpResponseAsync(searchRelevanceInput).Result;
            Assert.NotNull(response);
        }
    }
}
