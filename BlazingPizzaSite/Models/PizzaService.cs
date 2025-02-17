using System.Net.Http;
using System.Text.Json;

namespace BlazingPizzaSite.Models
{
    public class PizzaService
    {
        private readonly HttpClient httpClient;

        public PizzaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Pizza>> GetPizzasAsync()
        {
            var response = await httpClient.GetAsync("sample-data/pizzas.json");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Pizza>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return new List<Pizza>();
            }
        }
    }
}
