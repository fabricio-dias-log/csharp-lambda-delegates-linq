namespace ExpLambdaDelegatesLINQ.Entities;

public class Linq {
    public void init() {
        Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
        Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
        Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };
                    
        List<Product> newProducts = new List<Product>() {
            new Product("Computer", 1100.0, c2),
            new Product("Hammer", 90.0, c1),
            new Product("TV", 1700.0, c3),
            new Product("Notebook", 1300.0, c2),
            new Product("Saw", 80.0, c3),
            new Product("Tablet", 700.0, c2),
            new Product("Camera", 700.0, c3),
            new Product("Printer", 350.0, c3),
            new Product("MacBook", 1800.0, c2),
            new Product("Sound Bar", 700.0, c3),
            new Product("Level", 70.0, c2)
        };
        
        var r1 = newProducts.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
        Print("TIER 1 AND PRICE < 900", r1);
        
        var r2 = newProducts.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
        Print("NAME OF TIER 1", r2);
        
        var r3 = newProducts.Where(p => p.Name[0] == 'C')
            .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
        Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);
        
        var r4 = newProducts.Where(p => p.Category.Tier == 1)
            .OrderBy(p => p.Price).ThenBy(p => p.Name);
        Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);
        
        var r5 = r4.Skip(2).Take(4);
        Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);
        
        var r6 = newProducts.FirstOrDefault();
        Console.WriteLine("First or default test 1: " + r6);
        
        var r7 = newProducts.Where(p => p.Price < 3000.0).FirstOrDefault();
        Console.WriteLine("First or default test 2: " + r7);
        Console.WriteLine();
        
        var r8 = newProducts.Where(p => p.Category.Id == 1).SingleOrDefault();
        Console.WriteLine("Single or default test 1: " + r8);
        
        var r9 = newProducts.Where(p => p.Category.Id == 1).SingleOrDefault();
        Console.WriteLine("Single or default test 2: " + r9);
        Console.WriteLine();
        
        var r10 = newProducts.Max(p => p.Price);
        Console.WriteLine("Max price: " + r10);
        
        var r11 = newProducts.Min(p => p.Price);
        Console.WriteLine("Min price: " + r11);
        
        var r12 = newProducts.Where(p => p.Category.Id == 1).Sum(p => p.Price);
        Console.WriteLine("Category 1 sum prices: " + r12);
        
        var r13 = newProducts.Where(p => p.Category.Id == 1).Average(p => p.Price);
        Console.WriteLine("Category 1 average prices: " + r13);
        
        var r14 = newProducts.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
        Console.WriteLine("Category 5 average prices: " + r14);
        Console.WriteLine();
        
        var r15 = newProducts.Where(p => p.Category.Id == 2).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
        Console.WriteLine("Category 2 aggregate sum: " + r15);
        
        var r16 = newProducts.GroupBy(p => p.Category);
        foreach (IGrouping<Category, Product> group in r16) {
            Console.WriteLine("Category " + group.Key.Name + ":");
            foreach (Product p in group) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
    }
    
    static void Print<T>(string message, IEnumerable<T> collection) {
        Console.WriteLine(message);
        foreach (T obj in collection) {
            Console.WriteLine(obj);
        }
        Console.WriteLine();
    }
}