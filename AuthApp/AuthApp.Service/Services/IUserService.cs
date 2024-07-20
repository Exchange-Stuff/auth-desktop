using AuthApp.Service.Constants;
using AuthApp.Service.Models;
using AuthApp.Service.Statics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthApp.Service.Services
{
    public interface IUserService
    {
        Task<List<UserAddGroupPermission>> GetUsers();
        Task Logout();
        Task<bool> UpdateUserPermissionGroup(UserPermissionGroupUpdate userPermissionGroupUpdate);
        Task<List<AccountViewModel>> GetAccounts(string? username = null!);
        Task<bool> CreateAccount(AccountCreateModel accountCreateModel);
    }
    public class UserService : IUserService
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
        public async Task<List<UserAddGroupPermission>> GetUsers()
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                HttpResponseMessage httpResponse = await http.GetAsync(EndpointAPI.USERS_GET);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseStr = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseStr))
                    {
                        JObject jobj = JObject.Parse(responseStr);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var permissionString = jobj["value"]?["listItem"] + "";
                            if (!string.IsNullOrEmpty(permissionString))
                            {
                                return JsonConvert.DeserializeObject<List<UserAddGroupPermission>>(permissionString)!;
                            }
                        }
                    }
                }
            }
            return null!;
        }

        public async Task<List<AccountViewModel>> GetAccounts(string? username = null!)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var usernams = username != null! ? $"?username={username.Trim()}" : "";
                HttpResponseMessage httpResponse = await http.GetAsync(EndpointAPI.ACCOUNTS_GET + usernams);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");
                string responseStsr = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseStr = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseStr))
                    {
                        JObject jobj = JObject.Parse(responseStr);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var permissionString = jobj["value"]?["listItem"] + "";
                            if (!string.IsNullOrEmpty(permissionString))
                            {
                                return JsonConvert.DeserializeObject<List<AccountViewModel>>(permissionString)!;
                            }
                        }
                    }
                }
            }
            return null!;
        }

        public async Task<bool> UpdateUserPermissionGroup(UserPermissionGroupUpdate userPermissionGroupUpdate)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var param = userPermissionGroupUpdate;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PutAsync(EndpointAPI.PERMISSION_GROUP_USER_UPDATE, stringContent);
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

        public async Task<bool> CreateAccount(AccountCreateModel accountCreateModel)
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                var param = accountCreateModel;
                string paramString = JsonConvert.SerializeObject(param);
                StringContent stringContent = new StringContent(paramString, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PostAsync(EndpointAPI.CREATE_ACCOUNT_POST, stringContent);
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
