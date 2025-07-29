namespace ExpLambdaDelegatesLINQ.Entities;

public class Product : IComparable<Product> {
    public string Name { get; set; }
    public double Price { get; set; }
    
    public Product(string name, double price) {
        Name = name;
        Price = price;
    }
    
    public override string ToString() {
        return $"{Name} - {Price:C}";
    }
    
    // Implementing IComparable to allow sorting by Name
    // This will sort the products by their names in a case-insensitive manner
    public int CompareTo(Product? other) {
        return Name.ToUpper().CompareTo(other.Name.ToUpper());
    }
}