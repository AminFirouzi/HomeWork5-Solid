using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

public interface IProductRepository
{
    List<string> GetProducts();
}

public class DatabaseProductRepository : IProductRepository
{
    public List<string> GetProducts()
    {
        return new List<string> { "Database Product 1", "Database Product 2" };
    }
}

public class ApiProductRepository : IProductRepository
{
    public List<string> GetProducts()
    {
        return new List<string> { "API Product 1", "API Product 2" };
    }
}

public class FileProductRepository : IProductRepository
{
    public List<string> GetProducts()
    {
        return new List<string> { "File Product 1", "File Product 2" };
    }
}

public class ProductDisplay
{
    private readonly IProductRepository _repository;

    public ProductDisplay(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Display()
    {
        List<string> products = _repository.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}

class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IProductRepository, ApiProductRepository>();
        serviceCollection.AddTransient<ProductDisplay>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var display = serviceProvider.GetRequiredService<ProductDisplay>();
        display.Display();
    }
}