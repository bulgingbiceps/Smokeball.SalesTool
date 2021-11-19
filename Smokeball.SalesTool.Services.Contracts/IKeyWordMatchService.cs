using Smokeball.SalesTool.Models;
using System.Collections.Generic;

namespace Smokeball.SalesTool.Contracts
{
    /// <summary>
    /// Responsible for Keyword Matchign
    /// </summary>
    public interface IKeyWordMatchService
    {
        List<int> CountMatches(SearchRelevanceInput searchRelevanceInput, string response);
    }
}
