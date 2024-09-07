using AppFakeStore.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using AppFakeStore.Utils;

namespace AppFakeStore.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient client;

        public LoginService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var loginRequest = new LoginRequest
            {
                username = username,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Constants.LoginEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return responseContent;
            }

            return null; // Maneja errores de autenticación según tu lógica
        }
    }
}
