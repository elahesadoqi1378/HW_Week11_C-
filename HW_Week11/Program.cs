using HW_Week11.Contracts;
using HW_Week11.Entities;
using HW_Week11.Repositories;

class Program
{
    static void Main(string[] args)
    {
        IProductRepository productRepository = new ProductRepository();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create a new product");
            Console.WriteLine("2. Show all products");
            Console.WriteLine("3. Show product by ID");
            Console.WriteLine("4. Edit product");
            Console.WriteLine("5. Remove a product");
            Console.WriteLine("6. Exit");

            var input = Console.ReadLine();
            if (input == "6") break;

            switch (input)
            {
                case "1":
                    var newProduct = new Product();
                    Console.Write("Enter product name: ");
                    newProduct.Name = Console.ReadLine();
                    Console.Write("Enter product categoryId:");
                    newProduct.CategoryId= Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter price: ");
                    newProduct.Price = Convert.ToInt32(Console.ReadLine());
                    productRepository.Create(newProduct);
                    Console.WriteLine("new product has build");
                    break;

                case "2":
                    var products = productRepository.GetAll();
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Category: {product.CategoryName}, Price: {product.Price}");
                    }
                    break;

                case "3":
                    Console.Write("Enter product ID: ");
                    int id = int.Parse(Console.ReadLine());
                    var productById = productRepository.Get(id);
                    if (productById != null)
                    {
                        Console.WriteLine($"ID: {productById.Id}, Name: {productById.Name}, Category: {productById.CategoryName}, Price: {productById.Price}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;

                

                case "4":

                    Console.Write("Enter product ID to edit: ");
                    int Id = int.Parse(Console.ReadLine());
                    var editProduct = productRepository.Get(Id);
                    if (editProduct != null)
                    {
                        Console.Write("Enter new name : ");
                        var newName = Console.ReadLine();
                        editProduct.Name = !string.IsNullOrWhiteSpace(newName) ? newName : editProduct.Name;

                        Console.Write("Enter new category ID :");
                        int newCatId = int.Parse(Console.ReadLine());
                        if (Product.IsValidCategoryId(newCatId))
                        {
                            editProduct.CategoryId = newCatId;
                        }
                        else
                        {
                            Console.WriteLine("Invalid category ID. No change will be made.");
                            break;
                        }
                        

                        Console.Write("Enter new price :");
                        int newPrice = int.Parse(Console.ReadLine());
                        editProduct.Price = newPrice;
                        productRepository.Update(editProduct);
                        Console.WriteLine("Product updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    break;


                case "5":
                    Console.Write("Enter product ID to remove: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    productRepository.Delete(deleteId);
                    Console.WriteLine("Product removed.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
