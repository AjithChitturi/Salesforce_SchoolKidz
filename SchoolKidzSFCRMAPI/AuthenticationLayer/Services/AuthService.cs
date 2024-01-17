using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SchoolKidzSFCRMAPI.AuthenticationLayer.Models;
using System.Security.Cryptography.Xml;

namespace SchoolKidzSFCRMAPI.AuthenticationLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationOption _AuthenticationOption;
        private readonly AuthResponse authResponse;

        public AuthService(IOptions<AuthenticationOption> options)
        {
            try
            {
                _AuthenticationOption = options.Value;
                var client = new HttpClient();
                var request = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type","password" },
                    {"client_id", _AuthenticationOption.ClientId },
                    {"client_secret", _AuthenticationOption.ClientSecret },
                    {"username", _AuthenticationOption.UserName },
                    {"password", _AuthenticationOption.Password}
                });

                var response = client.PostAsync("https://login.salesforce.com/services/oauth2/token", request).GetAwaiter().GetResult();
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " ::Ctor AuthService");
            }
        }
        public void RefreshToken()
        {
            try
            {
                var client = new HttpClient();
                if (authResponse.access_token != null)
                {
                    var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"grant_type", "refresh_token" },
                        {"client_id", _AuthenticationOption.ClientId },
                        {"client_secret", _AuthenticationOption.ClientSecret },
                        {"refresh_token", authResponse.access_token }
                    });
                    var response = client.PostAsync("https://login.salesforce.com/services/oauth2/token", request).GetAwaiter().GetResult();
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    authResponse.refresh(JsonConvert.DeserializeObject<AuthResponse>(jsonResponse));
                }
                else
                {
                    throw new Exception("Access_token null: Trying to refresh.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string getToken()
        {
            return authResponse.access_token;
        }
        public string getInstanceUrl()
        {
            return authResponse.instance_url;
        }
        public string getId()
        {
            return authResponse.id;
        }
        public string getTokenType()
        {
            return authResponse.token_type;
        }
        public string getIssue()
        {
            return authResponse.issued_at;
        }
        public string getSignature()
        {
            return authResponse.signature;
        }

    }
}
