using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(UserLogin userLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:63979/api/identity/login-user", loginContent);


            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public async Task<UserResponseLogin> Register(UserRegister userRegister)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(userRegister), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:63979/api/identity/new-user", loginContent);

            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }


}
