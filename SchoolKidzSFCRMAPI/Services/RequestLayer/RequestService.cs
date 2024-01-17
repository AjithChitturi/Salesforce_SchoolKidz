using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.AuthenticationLayer.Services;
using SchoolKidzSFCRMAPI.ModelsNew;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace SchoolKidzSFCRMAPI.Services.RequestLayer
{
    public class RequestService : IRequestService
    {
        private readonly IAuthService _AuthService;
        private HttpClient _httpClient;
        private readonly string _endPoint;
        public RequestService(IAuthService options, IConfiguration configuration)
        {
            _AuthService = options;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _AuthService.getToken());

            _endPoint = configuration.GetSection("AppSettings")["EndPoint"];

        }
        public async Task<string> Get(string inputId, bool idTake, string endPoint)
        {
            string jsonResponse;

            if (!idTake)
            {
                var queryUrl = $"{_AuthService.getInstanceUrl()}{endPoint}{Uri.EscapeDataString(inputId.ToString())}";
                var response = await _httpClient.GetAsync(queryUrl);
                if (response.IsSuccessStatusCode != true)
                {
                    throw new Exception(response.ToString() + "\n" + response.Content.ToString());
                }

                jsonResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                var Uri = $"{_AuthService.getInstanceUrl()}{_endPoint + endPoint}{inputId}";
                var response = await _httpClient.GetAsync(Uri);
                if (response.IsSuccessStatusCode != true)
                    throw new Exception(response.ToString() + "\n" + response.Content.ToString());
                jsonResponse = await response.Content.ReadAsStringAsync();
            }

            return jsonResponse;
        }
        public async Task<string> Post(Dictionary<string, string> take, string endPoint)
        {
            var accountJson = JsonConvert.SerializeObject(take);
            var accountContent = new StringContent(accountJson, Encoding.UTF8, "application/json");
            var Uri = $"{_AuthService.getInstanceUrl()}{_endPoint + endPoint}";
            var response = await _httpClient.PostAsync(Uri, accountContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode != true)
                throw new Exception(response.ToString() + "\n" + response.Content.ToString());
            return jsonResponse;
        }

        public async Task<string> Delete(string inputId, string endPoint)
        {
            var Uri = $"{_AuthService.getInstanceUrl()}{_endPoint + endPoint}/{inputId}";
            var response = await _httpClient.DeleteAsync(Uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode != true)
                throw new Exception(response.ToString() + "\n" + response.Content.ToString());
            return jsonResponse;
        }

        public async Task<bool> Put(string id, Dictionary<string,dynamic> model,string endPoint)
        {
            

            var accountJson = JsonConvert.SerializeObject(model);
            var accountContent = new StringContent(accountJson, Encoding.UTF8, "application/json");
            var Uri = $"{_AuthService.getInstanceUrl()}{_endPoint + endPoint}/{id}";
            var response = await _httpClient.PatchAsync(Uri, accountContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode != true)
                throw new Exception(response.ToString() + "\n" + response.Content.ToString());
            return true;
        }
    }
}
