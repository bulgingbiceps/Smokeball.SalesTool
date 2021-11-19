using Smokeball.SalesTool.Models;

namespace Smokeball.SalesTool.Contracts
{
    /// <summary>
    /// Responsible for Default parameters for Search
    /// </summary>
    public interface IDefaultParameterService
    {
        SearchRelevanceInput GetDefaultInput();

    }
}
