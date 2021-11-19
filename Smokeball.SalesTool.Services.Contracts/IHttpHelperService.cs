using Smokeball.SalesTool.Models;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Contracts
{
    public interface IHttpHelperService
    {
        Task<string> GetHttpResponseAsync(SearchRelevanceInput searchRelevanceInput);
    }
}
