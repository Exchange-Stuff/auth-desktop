using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using AuthApp.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthApp.Service.Services
{
    public interface IUserService
    {
        Task<List<UserAddGroupPermission>> GetUsers();
    }
    public class UserService : IUserService
    {
        public async Task<List<UserAddGroupPermission>> GetUsers()
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage httpResponse = await http.GetAsync(EndpointAPI.USERS_GET);
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
                                return JsonConvert.DeserializeObject<List<UserAddGroupPermission>>(permissionString)!;
                            }
                        }
                    }
                }
            }
            return null!;
        }
    }
}
