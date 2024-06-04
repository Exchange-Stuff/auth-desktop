using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AuthApp.Service.Services
{
    public interface IResourceService
    {
        Task<List<ResourceDTO>> GetResources();
    }
    public class ResourceService : IResourceService
    {
        public async Task<List<ResourceDTO>> GetResources()
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage httpResponse = await http.GetAsync(EndpointAPI.RESOURCES_GET);
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
    }
}
