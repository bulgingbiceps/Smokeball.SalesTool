using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using Smokeball.SalesTool.Services.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Services
{
    public class SearchRelevanceService: ISearchRelevanceService
    {
        private IHttpHelperService _httpHelperService;
        private IKeyWordMatchService _keyWordMatchService;

        public SearchRelevanceService(IHttpHelperService httpHelperService, IKeyWordMatchService keyWordMatchService)
        {
            _httpHelperService = httpHelperService;
            _keyWordMatchService = keyWordMatchService;
        }

        public async Task<SearchRelevanceOutput> GetSearchRelevance(SearchRelevanceInput searchRelevanceInput)
        {
            string response = await _httpHelperService.GetHttpResponseAsync(searchRelevanceInput);
            List<int> indexes = _keyWordMatchService.CountMatches(searchRelevanceInput, response);
            return new SearchRelevanceOutput { Result = Constants.SuccessMessage, RelevanceIndex = indexes };
        }
    }
}
