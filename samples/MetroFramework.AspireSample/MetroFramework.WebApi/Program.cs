var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

// Sample data endpoints
app.MapGet("/api/products", () =>
{
    return new[]
    {
        new Product(1, "Metro Button Widget", "A modern button control", 29.99m, "Controls"),
        new Product(2, "Metro Theme Pack", "Dark and Light themes", 49.99m, "Themes"),
        new Product(3, "Metro Progress Kit", "Progress bars and spinners", 19.99m, "Controls"),
        new Product(4, "Metro Form Designer", "Visual form designer", 99.99m, "Tools"),
        new Product(5, "Metro Tile Collection", "Customizable tiles", 39.99m, "Controls")
    };
}).WithName("GetProducts");

app.MapGet("/api/products/{id}", (int id) =>
{
    var products = new Dictionary<int, Product>
    {
        { 1, new Product(1, "Metro Button Widget", "A modern button control", 29.99m, "Controls") },
        { 2, new Product(2, "Metro Theme Pack", "Dark and Light themes", 49.99m, "Themes") },
        { 3, new Product(3, "Metro Progress Kit", "Progress bars and spinners", 19.99m, "Controls") },
        { 4, new Product(4, "Metro Form Designer", "Visual form designer", 99.99m, "Tools") },
        { 5, new Product(5, "Metro Tile Collection", "Customizable tiles", 39.99m, "Controls") }
    };

    return products.TryGetValue(id, out var product) 
        ? Results.Ok(product) 
        : Results.NotFound();
}).WithName("GetProductById");

app.MapGet("/api/categories", () =>
{
    return new[] { "Controls", "Themes", "Tools", "Documentation" };
}).WithName("GetCategories");

app.MapGet("/api/stats", () =>
{
    return new Stats(
        TotalProducts: 5,
        TotalCategories: 4,
        AveragePrice: 47.99m,
        LastUpdated: DateTime.UtcNow
    );
}).WithName("GetStats");

app.Run();

record Product(int Id, string Name, string Description, decimal Price, string Category);
record Stats(int TotalProducts, int TotalCategories, decimal AveragePrice, DateTime LastUpdated);
