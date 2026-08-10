using Microsoft.EntityFrameworkCore;
using RetailInventory;
using RetailInventory.Models;

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=RetailInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;";

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new AppDbContext(optionsBuilder.Options);

await context.Database.MigrateAsync();

if (!await context.Categories.AnyAsync())
{
    var categories = new List<Category>
    {
        new() { Name = "Electronics" },
        new() { Name = "Groceries" }
    };

    await context.Categories.AddRangeAsync(categories);
    await context.SaveChangesAsync();
}

var electronics = await context.Categories.FirstAsync(c => c.Name == "Electronics");
var groceries = await context.Categories.FirstAsync(c => c.Name == "Groceries");

if (!await context.Products.AnyAsync())
{
    var products = new List<Product>
    {
        new() { Name = "Laptop", Price = 999.99m, CategoryId = electronics.Id },
        new() { Name = "Rice Bag", Price = 25.50m, CategoryId = groceries.Id }
    };

    await context.Products.AddRangeAsync(products);
    await context.SaveChangesAsync();
}

Console.WriteLine("All products:");
foreach (var product in await context.Products.Include(p => p.Category).ToListAsync())
{
    Console.WriteLine($"{product.Id}: {product.Name} - {product.Price:C} - Category: {product.Category?.Name}");
}

var productById = await context.Products.FindAsync(1);
Console.WriteLine($"\nProduct by Id 1: {productById?.Name}");

var productByPrice = await context.Products.FirstOrDefaultAsync(p => p.Price > 50);
Console.WriteLine($"\nFirst product with price > 50: {productByPrice?.Name}");
