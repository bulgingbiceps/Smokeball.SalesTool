using Smokeball.SalesTool.Models;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Contracts
{
    /// <summary>
    /// Responsible for Calculating Search relevance
    /// </summary>
    public interface ISearchRelevanceService
    {
        Task<SearchRelevanceOutput> GetSearchRelevance(SearchRelevanceInput searchRelevanceInput);
    }
}
