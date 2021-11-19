using Smokeball.SalesTool.Models;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Contracts
{
    /// <summary>
    /// Responsible for All HTTP methods
    /// </summary>
    public interface IHttpHelperService
    {
        Task<string> GetHttpResponseAsync(SearchRelevanceInput searchRelevanceInput);
    }
}
