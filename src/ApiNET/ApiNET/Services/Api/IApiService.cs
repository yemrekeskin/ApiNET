using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface IApiService
    {
        string ApiUrl { get; set; }

        Dictionary<string, string> Header { get; set; }

        Dictionary<string, string> Parameter { get; set; }

        Task<ApiResponse<T>> InvokeGet<T>(string path);

        Task<ApiResponse<T>> InvokePost<T>(string path);
    }
}