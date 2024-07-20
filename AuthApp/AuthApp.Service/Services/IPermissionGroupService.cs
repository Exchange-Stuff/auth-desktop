using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using AuthApp.Service.Statics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthApp.Service.Services
{
    public interface IPermissionGroupService
    {
        Task<List<PermissionGroupDTO>> GetPermissionGroupDTOs();
        Task<List<PermissionDTO>> GetPermissionDTO();
        Task<bool> UpdateGroupPermission(UpdatePermissionGroupModel updatePermissionGroupModel);
        Task<bool> CreatePermissionGroup(CreatePermissionGroupModel createPermissionGroupModel);
        Task<bool> UpdateResourceGroupPermission(UpdatePermissionGroupModel updatePermissionGroupModel);
        Task Logout();
    }

    public class PermissionGroupService : IPermissionGroupService
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
        public async Task<bool> CreatePermissionGroup(CreatePermissionGroupModel createPermissionGroupModel)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var param = createPermissionGroupModel;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PostAsync(EndpointAPI.PERMISSION_GROUP_POST, stringContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

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

        public async Task<List<PermissionDTO>> GetPermissionDTO()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                HttpResponseMessage response = await client.GetAsync(EndpointAPI.PERMISSIONS_GET);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

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
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                HttpResponseMessage response = await client.GetAsync(EndpointAPI.PERMISSION_GROUPS_GET);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

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
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var param = updatePermissionGroupModel;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PutAsync(EndpointAPI.PERMISSIONS_UPDATE, stringContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

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
        public async Task<bool> UpdateResourceGroupPermission(UpdatePermissionGroupModel updatePermissionGroupModel)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var param = updatePermissionGroupModel;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PutAsync(EndpointAPI.PERMISSION_GROUP_RESOURCE_PUT, stringContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

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
