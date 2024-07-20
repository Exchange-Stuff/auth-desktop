using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using AuthApp.Service.Statics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace AuthApp.Service.Services
{
    public interface IResourceService
    {
        Task<List<ResourceDTO>> GetResources();
        Task<bool> CreateResource(string name);
        Task Logout();
    }
    public class ResourceService : IResourceService
    {
        private string _mediaType = "application/json";

        public async Task Logout()
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);
                HttpResponseMessage httpResponse = await http.PostAsync(EndpointAPI.LOGOUT_POST, null!);
            }
        }
        public async Task<List<ResourceDTO>> GetResources()
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                HttpResponseMessage httpResponse = await http.GetAsync(EndpointAPI.RESOURCES_GET);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseStr = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseStr))
                    {
                        JObject jobj = JObject.Parse(responseStr);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var permissionString = jobj["value"] + "";
                            if (!string.IsNullOrEmpty(permissionString))
                            {
                                return JsonConvert.DeserializeObject<List<ResourceDTO>>(permissionString)!;
                            }
                        }
                    }
                }
            }
            return null!;
        }
        public async Task<bool> CreateResource(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            using (HttpClient http = new HttpClient())
            {
                string js = $"\"{name}\"";
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                StringContent stringContent = new StringContent(js, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PostAsync(EndpointAPI.RESOURCE_POST, stringContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");
                var a = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.IsSuccessStatusCode)
                {
                    string resultString = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(resultString))
                    {
                        JObject jobj = JObject.Parse(resultString);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    throw new Exception("Server has problem, can't create");
                }
            }
            return false;
        }
    }
}
