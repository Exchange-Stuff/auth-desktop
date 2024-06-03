using AuthApp.Service.Constants;
using AuthApp.Service.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace AuthApp.Service.Services
{
    public interface IAuthService
    {
        Task<ClaimDTO> Login(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private string _mediaType = "application/json";
        private JwtDTO _jwtDTO = new JwtDTO();
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration= configuration;
            _configuration.GetSection(nameof(JwtDTO)).Bind(_jwtDTO);
        }
        public async Task<ClaimDTO> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Username and password is not empty");
            using (HttpClient httpClient = new HttpClient())
            {
                var param = new
                {
                    username = username,
                    password = password
                };
                string dataJson = JsonConvert.SerializeObject(param);
                StringContent content = new StringContent(dataJson, System.Text.Encoding.UTF8, _mediaType);
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(EndpointAPI.SUPER_ADMIN_LOGIN_POST, content);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string responseData = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseData))
                    {
                        JObject jobj = JObject.Parse(responseData);
                        if ((jobj["isSuccess"] + "").ToLower() == "true")
                        {
                            var token = jobj["value"] + "";
                            if (!string.IsNullOrEmpty(token))
                            {
                                return GetClaimDTOByAccessTokenSynchronous(token);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Can't read data result");
                    }
                }
                else
                {
                    return null!;
                }
            }
            return null!;
        }

        public ClaimDTO GetClaimDTOByAccessTokenSynchronous(string? token = null!)
        {
            if (token == null!) return null!;
            try
            {
                var keyExample = _jwtDTO.JwtSecret;
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyExample)),
                    ValidateIssuer = false, //**
                    ValidateAudience = false, //** 
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _jwtDTO.Issuer,
                    ValidAudience = _jwtDTO.Audience,

                }, out SecurityToken securityToken);
                var jwtToken = (JwtSecurityToken)securityToken;
                var id = jwtToken.Claims.First(x => x.Type == "nameid")!.Value;
                if (Guid.TryParse(id, out Guid newId) is false )
                {
                    return null!;
                }
                return new ClaimDTO
                {
                    Id = newId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
