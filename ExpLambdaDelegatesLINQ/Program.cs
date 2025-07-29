using ExpLambdaDelegatesLINQ.Entities;

namespace ExpLambdaDelegatesLINQ;

class Program {
    static void Main(string[] args) {
        int option;
        do {
            Console.Clear();
            Console.WriteLine("1. Use Comparison with products");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            option = int.Parse(Console.ReadLine() ?? "0");
            switch (option) {
                case 1:
                    List<Product> productList = new List<Product> {
                        new Product("Laptop", 1200.00),
                        new Product("Smartphone", 800.00),
                        new Product("Tablet", 300.00)
                    };
                    
                    // Sort based on the CompareProducts method using a delegate
                    // just using the method name directly 
                    productList.Sort((p1, p2) => {;
                        // Using a lambda expression to compare products by name
                        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
                    });

                    foreach (var product in productList) {
                        Console.WriteLine(product);
                    }
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        } while (option != 6);
    }
}