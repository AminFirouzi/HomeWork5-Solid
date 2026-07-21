using System;
using System.Collections.Generic;

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

public static class ProductRepositoryFactory
{
    public static IProductRepository CreateRepository(string sourceType)
    {
        switch (sourceType.ToLower())
        {
            case "database":
                return new DatabaseProductRepository();
            case "api":
                return new ApiProductRepository();
            case "file":
                return new FileProductRepository();
            default:
                throw new ArgumentException("Invalid source type specified.");
        }
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
        string configSource = "api"; 

        IProductRepository repository = ProductRepositoryFactory.CreateRepository(configSource);
        
        ProductDisplay display = new ProductDisplay(repository);
        display.Display();
    }
}