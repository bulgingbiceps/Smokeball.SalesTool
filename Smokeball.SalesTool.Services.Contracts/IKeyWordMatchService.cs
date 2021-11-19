using Smokeball.SalesTool.Models;
using System.Collections.Generic;

namespace Smokeball.SalesTool.Contracts
{
    public interface IKeyWordMatchService
    {
        List<int> CountMatches(SearchRelevanceInput searchRelevanceInput, string response);
    }
}
