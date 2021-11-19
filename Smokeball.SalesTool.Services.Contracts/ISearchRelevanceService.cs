using Smokeball.SalesTool.Models;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Contracts
{
    public interface ISearchRelevanceService
    {

        Task<SearchRelevanceOutput> GetSearchRelevance(SearchRelevanceInput searchRelevanceInput);
    }
}
