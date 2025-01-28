using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using BrassAndPoem;

namespace BrassAndPoem{
    public class Inventory
    {
        static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Name = "A Collection Williams Wordsworth",
                Price = 20,
                ProductTypeId = 1,
            },
            new Product()
            {
                Name = "Saxaphone",
                Price = 150,
                ProductTypeId = 2,
            },
            new Product()
            {
                Name = "Robert Frost Original Works",
                Price = 30,
                ProductTypeId = 1
            },
            new Product()
            {
                Name = "Trumpet",
                Price = 200,
                ProductTypeId = 2,
            },
            new Product()
            {
                Name = "Where the Sidewalk Ends",
                Price = 15,
                ProductTypeId = 1,
            }
        };
        //create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
        static List<ProductType> productTypes = new List<ProductType>()
        {
            new ProductType()
            {
                Title = "PoetryBooks",
                Id = 1,
            },
            new ProductType()
            {
                Title = "BrassInstruments",
                Id = 2,
            }
        };

            //put your greeting here
            string greeting = "Welcome to Brass and Poem\nYour online supplier of all your\nPoetry and Brass Instrument Needs!";
            
        static void Main(string[] args)
        {
            //implement your loop here
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = DisplayMenu();
            }
        }
        private static bool DisplayMenu()
        {
            var inv = new Inventory();
            Console.WriteLine("");
            Console.WriteLine(inv.greeting);
            Console.WriteLine("");
            Console.WriteLine("Option 1: Display All Products");
            Console.WriteLine("Option 2: Delete Product");
            Console.WriteLine("Option 3: Add Product");
            Console.WriteLine("Option 4: Update Product");
            Console.WriteLine("Option 5: Exit");
            Console.WriteLine("Please select from a menu option");

            switch (Console.ReadLine())
            {
                case "1":
                Console.Clear();
                DisplayAllProducts();
                return true;
                case "2":
                Console.Clear();
                DeleteProduct();
                return true;
                case "3":
                Console.Clear();
                AddProduct();
                return true;
                case "4":
                Console.Clear();
                UpdateProduct();
                return true;
                case "5":
                Console.Clear();
                Exit();
                return true;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option from the menu.");
                    Console.ReadLine();
                    return true;
            }
        }

        static void DisplayAllProducts()
        {
            int counter = 1;
            
            // joining the Product table with the ProductType table
            var joinId = from product in Inventory.products  
                        join productType in Inventory.productTypes on product.ProductTypeId equals productType.Id
                        select new {
                            ProductType = productType.Title,
                            ProductName = product.Name,
                            ProductPrice = product.Price
                            };

            foreach(var item in joinId)
            {
                Console.WriteLine(@$"{counter}. {item.ProductType} {item.ProductName} {item.ProductPrice:C}" );
                counter++;
            }
        }

        static void DeleteProduct()
        {
                DisplayAllProducts();
                Console.WriteLine("\nPlease select the product number you wish to delete");
                
                int response = int.Parse(Console.ReadLine().Trim())-1;
                Inventory.products.RemoveAt(response);

                DisplayAllProducts(); 
                Console.ReadLine();
        }
           
        
        static void AddProduct()
        {
            Console.WriteLine("\nPlease complete all the following prompts to add a product to our site. ");
            
            Console.WriteLine("Product Name: ");
            string name = Console.ReadLine();
        
            Console.WriteLine("\nPlease enter the price of the product: ");
            int price = int.Parse(Console.ReadLine());

            Console.WriteLine
            (@"1 = Poetry Books
            2 = Brass Instrument 
            Please enter the category number for your item: ");
            int productTypeId = int.Parse(Console.ReadLine()); 

            Product newProduct = new Product
            {Name = name,
            Price = price,
            ProductTypeId = productTypeId,
            };

            Inventory.products.Add(newProduct);
            DisplayAllProducts();
            Console.ReadLine();
        }

        static void UpdateProduct()
        {
            DisplayAllProducts();

            Console.WriteLine("\nPlease select the the product number you wish to update: ");
            
            int response = int.Parse(Console.ReadLine().Trim())-1;
            
            Console.WriteLine("Please update the name and press enter,\n if no changes needed just press the enter button.");
            Console.WriteLine(Inventory.products[response].Name);
            var updatedName = Console.ReadLine();
            
            if (updatedName != null && updatedName != "")
            {
                Inventory.products[response].Name = updatedName;
            }

            Console.WriteLine("Please update the price and press enter,\nif no changes needed just press the enter button.");
            Console.WriteLine(Inventory.products[response].Price);
            
            string input = Console.ReadLine();

            if(!string.IsNullOrEmpty(input) && int.TryParse(input, out int updatedPrice))
            {
            Inventory.products[response].Price = updatedPrice;
            }
         
            Console.WriteLine
            (@"Please update the Product Type Id and press enter,
            if no changes needed just press the enter button.
            Remember: 
            1 = Poetry Books
            2 = Brass Instrument");
            Console.WriteLine(Inventory.products[response].ProductTypeId);
            
            string input2 = Console.ReadLine();

            if (!string.IsNullOrEmpty(input2) && int.TryParse(input2, out int updatedProductId) && (updatedProductId == 1 || updatedProductId == 2))
            {
                Inventory.products[response].ProductTypeId = updatedProductId;
            }

            DisplayAllProducts();
        }

        static void Exit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Are you sure you would like to exit the application?");
                Console.WriteLine("\nPress the 'y' to confirm or 'n' to return to the main menu?");
                
                string exitQuestion = Console.ReadLine();

                if (exitQuestion != null)
                {
                    if (exitQuestion.ToLower() == "n")
                    {
                        return;
                    }
                else if (exitQuestion.ToLower() == "y") 
                    {
                    Console.WriteLine("Thank you for stopping by!");
                    System.Environment.Exit(1);
                    }
                else
                    {
                        Console.WriteLine("Invalid option. Please press 'y' to exit or 'n' for the main menu.");
                    } 
                }
            }
        }
    }
};
    // don't move or change this!
    public partial class Program { }
