using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using OnlineShop.DTO;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;
    private readonly IOptions<ApplicationSettingsOptions> _appSettings;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger,  IOptions<ApplicationSettingsOptions> appSettings)
    {
        _httpClient = httpClient;
        _appSettings = appSettings;
        _httpClient.BaseAddress = new Uri(_appSettings.Value.ProductApiBaseUrl);
        _logger = logger;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("api/products");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Successfully fetched Product json");
        return JsonSerializer.Deserialize<List<Product>>(json);
    }

      public async Task<List<Category>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync("products/categories");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("Successfully fetched Category json");
        return JsonSerializer.Deserialize<List<Category>>(json);
    }
}