using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AuthApp.Service.Models;
using AuthApp.Service.Statics;

namespace AuthApp.Service.Services
{
    public interface IActionService
    {
        Task<List<ActionDTO>> GetActions();
        Task<bool> CreateAction(string name);
        Task Logout();
    }

    public class ActionService : IActionService
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
        public async Task<List<ActionDTO>> GetActions()
        {
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                HttpResponseMessage responseMsg = await http.GetAsync(EndpointAPI.ACTIONS_GET);
                if (responseMsg.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");
                if (responseMsg.IsSuccessStatusCode)
                {
                    var content = await responseMsg.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        JObject jobj = JObject.Parse(content);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var actions = jobj["value"] + "";
                            if (!string.IsNullOrEmpty(actions))
                            {
                                return JsonConvert.DeserializeObject<List<ActionDTO>>(actions)!;
                            }
                        }
                    }
                }
            }
            return null!;
        }

        public async Task<bool> CreateAction(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            using (HttpClient http = new HttpClient())
            {
                string js = $"\"{name}\"";
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenValue.Token);

                StringContent stringContent = new StringContent(js, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponse = await http.PostAsync(EndpointAPI.ACTION_POST, stringContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Login session expired");
                var a= await httpResponse.Content.ReadAsStringAsync(); 
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
