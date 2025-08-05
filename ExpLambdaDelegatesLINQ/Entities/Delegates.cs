using ExpLambdaDelegatesLINQ.Services;

namespace ExpLambdaDelegatesLINQ.Entities;

delegate double BinaryNumericOperation(double x, double y);

public class Delegates {
    public void init() {
        double a = 10;
        double b = 12;

        double result = CalculationService.Sum(a, b);
        
        BinaryNumericOperation op = CalculationService.Sum;
        result = op(a, b);
        Console.WriteLine(result);
    }
}