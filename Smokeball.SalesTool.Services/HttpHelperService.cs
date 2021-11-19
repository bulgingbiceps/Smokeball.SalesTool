using Smokeball.SalesTool.Contracts;
using Smokeball.SalesTool.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Smokeball.SalesTool.Services
{
    public class HttpHelperService: IHttpHelperService
    {
        public async Task<string> GetHttpResponseAsync(SearchRelevanceInput searchRelevanceInput)
        {
            var client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetStringAsync(searchRelevanceInput.SearchUrl);
            return response;
        }
    }


}
