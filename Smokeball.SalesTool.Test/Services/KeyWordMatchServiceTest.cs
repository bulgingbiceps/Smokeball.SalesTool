using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.Services;
using Smokeball.SalesTool.Test.Shared;
using Xunit;

namespace Smokeball.SalesTool.Test.Services
{
    public class KeyWordMatchServiceTest
    {
        const string DefaultSearchUrl = @"https://www.google.com.au/search?num=100&q=conveyancing+software";
        const string DefaultSearcKeyWord = @"smokeball.com.au";
        const string SearchPattern = "<div class=\"BNeawe UPmit AP7Wnd\">(.*?)</div>";

        [Fact]
        public void TestKeyWordMatchService()
        {
            var response = ResourceHelper.GetRsourceAsString("Resources.SampleResponse.txt");
            var keyWordMatchService =new KeyWordMatchService();
            //var searchRelevanceInput = new SearchRelevanceInput() { SearchKeyWord = DefaultSearcKeyWord, SearchPattern = SearchPattern, SearchUrl = DefaultSearchUrl };
            var searchRelevanceInput = DefaultObjectsHelper.GetSearchRelevanceInput();
            var matches = keyWordMatchService.CountMatches(searchRelevanceInput, response);
            Assert.NotNull(matches);
            Assert.Single(matches);

        }
    }
}
