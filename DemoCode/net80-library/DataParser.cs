namespace net80_library;

public class DataParser
{
    private ICurrentLogger? logger;

    public DataParser(ICurrentLogger logger)
    {
        // C# 6 nameof expression
        //if (logger is null)
        //    throw new ArgumentNullException(nameof(logger));

        // C# 7 throw expression
        // C# 6 nameof expression
        //this.logger = logger is not null 
        //            ? logger 
        //            : throw new ArgumentNullException(nameof(logger));

        // C# 8 Null coalescing operator
        // C# 7 throw expression
        // C# 6 nameof expression
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool TryParseInt(string input, out int parsedValue)
    {
        // C# 7 out variables
        //int value;
        //bool success = int.TryParse(input, out value);

        bool success = int.TryParse(input, out int value);
        if (success)
        {
            // C# 6 Null conditional operator
            logger?.Log($"Success: parsed {input} as {value}");
            parsedValue = value;
            return true;
        }
        else
        {
            // C# 6 Null conditional operator
            logger?.Log($"Failure: could not parse {input}");
            parsedValue = default;
            return false;
        }
    }

    public (bool Success, int Value) ParseInt(string? input)
    {
        // switch statement (been around for a loooooong time)
        //bool success = int.TryParse(input, out int parsedValue);
        //switch (success)
        //{
        //    case true: return (true, parsedValue);
        //    case false: return (false, default);
        //}

        // C# 8 switch expression
        return int.TryParse(input, out int parsedValue) switch
        {
            true => (true, parsedValue),
            false => (false, default),
        };
    }

    // C# 8 notnull generic type constraint
    public TResult Parse<TResult>(string input) where TResult : notnull
    {
        throw new NotImplementedException();
    }
}
