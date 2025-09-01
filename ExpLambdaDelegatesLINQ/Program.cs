using ExpLambdaDelegatesLINQ.Entities;
using ExpLambdaDelegatesLINQ.Services;
using System.Linq;

namespace ExpLambdaDelegatesLINQ;
delegate void BinaryNumericOperation(double n1, double n2);
class Program {
    static void Main(string[] args) {
        int option;
        do {
            Console.Clear();
            Console.WriteLine("1. Use Comparison with products");
            Console.WriteLine("2. Use Multicast Delegate");    
            Console.WriteLine("3. Use Predicate Delegate");    
            Console.WriteLine("4. Use Action Delegate");    
            Console.WriteLine("5. Use Func Delegate");    
            Console.WriteLine("6. Use LINQ");    
            Console.WriteLine("0. Exit");
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
                case 2:
                    double a = 12;
                    double b = 10;
                    
                    BinaryNumericOperation op = CalculationService.ShowSum;
                    op += CalculationService.ShowMax;
                    
                    op.Invoke(a , b); // ou op(a,b);
                    break;
                case 3:
                    List<Product> products = new List<Product> {
                        new Product("TV", 900.00),
                        new Product("Mouse", 50.00),
                        new Product("Tablet", 350.50),
                        new Product("HD Case", 80.90)
                    };
                    products.RemoveAll(ProductTest);
                    
                    foreach (var product in products) {
                        Console.WriteLine(product);
                    }
                    break;
                case 4:
                    List<Product> listP = new List<Product> {
                        new Product("TV", 900.00),
                        new Product("Mouse", 50.00),
                        new Product("Tablet", 350.50),
                        new Product("HD Case", 80.90)
                    };
                    
                    Action<Product> action = p => { p.Price += p.Price * 0.1; };
                    listP.ForEach(action);
                    
                    foreach (var product in listP) {
                        Console.WriteLine(product);
                    }
                    break;
                case 5:
                    List<Product> listF = new List<Product> {
                        new Product("Tv", 900.00),
                        new Product("Mouse", 50.00),
                        new Product("Tablet", 350.50),
                        new Product("Hd case", 80.90)
                    };
                    
                    Func<Product, string> func = p => p.Name.ToUpper();

                    List<string> result = listF.Select(func).ToList();

                    foreach (var s in result) {
                        Console.WriteLine(s);
                    }
                    break;
                case 6:
                    int [] numbers = new int[] {2, 3, 4, 5};
                    
                    var resultLinq = numbers
                        .Where(x => x % 2 == 0)
                        .Select(x => x * 10);
                    
                    foreach (int n in resultLinq) {
                        Console.WriteLine(n);
                    }
                    break;
                case 0:
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
    
    public static bool ProductTest(Product p) {
        return p.Price >= 100.0;
    }
    
    public static void UpdatePrice(Product p) {
        p.Price += p.Price * 0.1;
    }
    
    public static string NameUpper(Product p) {
        return p.Name.ToUpper();
    }
    
    
}