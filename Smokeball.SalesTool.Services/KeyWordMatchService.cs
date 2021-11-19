using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Smokeball.SalesTool.Services
{
    public class KeyWordMatchService: IKeyWordMatchService
    {
        public List<int> CountMatches(SearchRelevanceInput searchRelevanceInput, string response)
        {
            var regex = new Regex(searchRelevanceInput.SearchPattern);
            var matches = regex.Matches(response).Cast<Match>().ToList();
            var matchingIndexes = matches.Select((x, i) => new { i, x })
                .Where(x => x.ToString().Contains(searchRelevanceInput.SearchKeyWord, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.i + 1)
                .ToList();
            return matchingIndexes;
        }
    }


}
