using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AuthApp.Service.Services
{
    public interface IActionService
    {
        Task<List<ActionDTO>> GetActions();
    }
    public class ActionService : IActionService
    {
        private string _mediaType = "application/json";

        public async Task<List<ActionDTO>> GetActions()
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage responseMsg = await http.GetAsync(EndpointAPI.ACTIONS_GET);
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
    }
}
