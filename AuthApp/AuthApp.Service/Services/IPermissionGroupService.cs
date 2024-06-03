using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthApp.Service.Services
{
    public interface IPermissionGroupService
    {
        Task<List<PermissionGroupDTO>> GetPermissionGroupDTOs();
        Task<List<PermissionDTO>> GetPermissionDTO();
        Task<bool> UpdateGroupPermission(UpdatePermissionGroupModel updatePermissionGroupModel);
    }

    public class PermissionGroupService : IPermissionGroupService
    {
        private string _mediaType = "application/json";

        public async Task<List<PermissionDTO>> GetPermissionDTO()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(EndpointAPI.PERMISSION_GET);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseData))
                    {
                        JObject jobj = JObject.Parse(responseData);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var permissionString = jobj["value"] + "";
                            if (!string.IsNullOrEmpty(permissionString))
                            {
                                return JsonConvert.DeserializeObject<List<PermissionDTO>>(permissionString)!;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status code: " + response.StatusCode);
                }
            }
            return null!;
        }

        public async Task<List<PermissionGroupDTO>> GetPermissionGroupDTOs()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(EndpointAPI.PERMISSION_GROUP_GET);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseData))
                    {
                        JObject jobj = JObject.Parse(responseData);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var permissionString = jobj["value"] + "";
                            if (!string.IsNullOrEmpty(permissionString))
                            {
                                return JsonConvert.DeserializeObject<List<PermissionGroupDTO>>(permissionString)!;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Status code: " + response.StatusCode);
                }
            }
            return null!;
        }

        public async Task<bool> UpdateGroupPermission(UpdatePermissionGroupModel updatePermissionGroupModel)
        {
            using (HttpClient http = new HttpClient())
            {
                var param = updatePermissionGroupModel;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PutAsync(EndpointAPI.PERMISSIONS_UPDATE_RANGE, stringContent);
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
                    throw new Exception("Server has problem, can't update");
                }
            }
            return false;
        }
    }
}
