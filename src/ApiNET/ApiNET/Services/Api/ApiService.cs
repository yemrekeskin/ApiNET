using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiNET.Services
{
    public class ApiService
        : IApiService
    {
        private readonly ILoggerFactory loggerFactory;

        public ApiService(ILoggerFactory loggerFactory)
        {
            this.Header = new Dictionary<string, string>();
            this.Parameter = new Dictionary<string, string>();
            this.ApiUrl = string.Empty;
            this.loggerFactory = loggerFactory;
        }

        public string ApiUrl { get; set; }

        public Dictionary<string, string> Header { get; set; }
        public Dictionary<string, string> Parameter { get; set; }

        public async Task<ApiResponse<T>> InvokeGet<T>(string path)
        {
            var result = new ApiResponse<T>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (this.Header.Count > 0)
                    {
                        foreach (var kvp in this.Header)
                        {
                            httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                        }
                    }

                    var queryUrl = string.Concat(this.ApiUrl, path, buildEndpointRoute());
                    var response = await httpClient.GetAsync(queryUrl);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    result.Success = true;
                    result.Result = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger("api-service");
                var log = string.Format("{0} | {1}", ex.Message, ex.StackTrace);
                logger.LogError(log, null);

                result.Success = false;
                result.Result = default(T);
            }

            this.Parameter.Clear();
            this.Header.Clear();

            return result;
        }

        public async Task<ApiResponse<T>> InvokePost<T>(string path)
        {
            var result = new ApiResponse<T>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (this.Header.Count > 0)
                    {
                        foreach (var kvp in this.Header)
                        {
                            httpClient.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                        }
                    }

                    //    var data = new FormUrlEncodedContent(this.Parameter.ToList());

                    var data = new StringContent(JsonConvert.SerializeObject(Parameter), Encoding.UTF8, "application/json");

                    var queryUrl = string.Concat(this.ApiUrl, path);
                    var response = await httpClient.PostAsync(queryUrl, data);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    result.Success = true;
                    result.Result = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger("api-service");
                var log = string.Format("{0} | {1}", ex.Message, ex.StackTrace);
                logger.LogError(log, null);

                result.Success = false;
                result.Result = default(T);
            }

            this.Parameter.Clear();
            this.Header.Clear();

            return result;
        }

        private string buildEndpointRoute()
        {
            UriBuilder uriBuilder = new UriBuilder();
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var urlParameter in this.Parameter)
            {
                query[urlParameter.Key] = urlParameter.Value;
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.Query;
        }
    }
}