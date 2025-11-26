using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MetroFramework.ApiClient
{
    public class ProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("/api/products");
            return response ?? new List<Product>();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"/api/products/{id}");
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<string>>("/api/categories");
            return response ?? new List<string>();
        }

        public async Task<Stats?> GetStatsAsync()
        {
            return await _httpClient.GetFromJsonAsync<Stats>("/api/stats");
        }
    }

    public record Product(int Id, string Name, string Description, decimal Price, string Category);
    public record Stats(int TotalProducts, int TotalCategories, decimal AveragePrice, DateTime LastUpdated);
}
