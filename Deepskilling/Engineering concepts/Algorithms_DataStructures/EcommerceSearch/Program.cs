using System;

class Product
{
    public int ProductId;
    public string ProductName;

    public Product(int id, string name)
    {
        ProductId = id;
        ProductName = name;
    }
}

class Program
{
    static void Main()
    {
        Product[] products =
        {
            new Product(101, "Laptop"),
            new Product(102, "Mobile"),
            new Product(103, "Headphones")
        };

        int searchId = 102;
        bool found = false;

        foreach (var product in products)
        {
            if (product.ProductId == searchId)
            {
                Console.WriteLine("Product Found: " + product.ProductName);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Product Not Found");
        }
    }
}