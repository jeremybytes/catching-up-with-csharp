using net80_library;
using PropertyFeatures;

namespace console_app;

class Program
{
    static async Task Main(string[] args)
    {
        await Task.Delay(1);
        //RunInterfaceSamples();
        //RunPropertySamples();
        //RunNullableAndExpressionSamples();
        await RunLambdaExpressionSamples();
    }

    static void RunInterfaceSamples()
    {
        ICurrentLogger logger = new ConsoleLogger();
        try
        {
            logger.Log("Test Message");
            throw new NotImplementedException("Jeremy did not implement this");
        }
        catch (Exception ex)
        {
            logger.LogException(ex);
        }
    }

    static void RunPropertySamples()
    {
        //RegularPolygon invalidPolygon = new();
        //Console.WriteLine($"Invalid: {invalidPolygon.NumberOfSides} sides with length of {invalidPolygon.SideLength}");

        RegularPolygon triangle =
            new(3, 5);
        // C# 9 init-only setters
        //triangle.NumberOfSides = 5;
        Console.WriteLine($"Triangle: {triangle.NumberOfSides} sides with length of {triangle.SideLength}");
        Console.WriteLine($"   Perimeter is {triangle.Perimeter}");

        RegularPolygon square = new() { NumberOfSides = 4, SideLength = 7 }; ;
        Console.WriteLine($"Square: {square.NumberOfSides} sides with length of {square.SideLength}");
        Console.WriteLine($"   Perimeter is {square.Perimeter}");
    }

    static void RunNullableAndExpressionSamples()
    {
        try
        {
            DataParser parser = new(new ConsoleLogger());
            // C# 9 Nullable reference types (do not prevent compilation)
            //DataParser parser = new(null);

            // C# 7 discards
            // C# 7 out variables
            _ = parser.TryParseInt("123", out int value);
            Console.WriteLine($"Output from console: value {value}");

            _ = parser.TryParseInt("345", out value);
            Console.WriteLine($"Output from console: value {value}");

            _ = parser.TryParseInt("abc", out value);
            Console.WriteLine($"Output from console: value {value}");

            _ = parser.TryParseInt(null, out value);
            Console.WriteLine($"Output from console: value {value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR - {ex.GetType()}\n{ex.Message}");
        }
    }

    static async Task RunLambdaExpressionSamples()
    {
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

        // C# 9 Lambda expression discard parameters
        await Parallel.ForEachAsync(numbers,
            async (currentNumber, _) =>
            {
                await Task.Delay(1);
                Console.WriteLine($"Number: {currentNumber}");
            });
    }

}
