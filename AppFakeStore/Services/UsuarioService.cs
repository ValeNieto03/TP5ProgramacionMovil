using AppFakeStore.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;
using AppFakeStore.Utils;

namespace AppFakeStore.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public UsuarioService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Usuario>> GetUserAsync()
        {
            var response = await client.GetAsync(Constants.UserEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>(options);

            return default;
        }

        public async Task<Usuario> GetUsuarioIdAsync(int id)
        {
            try
            {
                string endpoint = $"{Constants.UserEndpoint}/{id}";
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsByteArrayAsync();
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(jsonString, options);
                return usuario;
            }
            catch(HttpRequestException ex)
            {
                return null;
            }
        }
    }
}