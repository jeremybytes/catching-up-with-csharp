# Catching Up with C#

## Interfaces

### C# 8 Access modifiers on interface members
* Look at ```IOldLogger.cs```
```csharp
public interface IOldLogger
{
    void Log(string message);
}
```
* Try to add access modifier (compiler failure)  
* Look at ```ICurrentLogger.cs```
```csharp
public interface ICurrentLogger
{
    void Log(string message);
}
```
* Add ```public``` modifer
* Show ```ConsoleLogger.cs```  
* Show ```Program.cs``` and run
```csharp
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
        logger.Log(ex.GetType().ToString());
    }
}
```

### C# 8 Default interface member implementation
* Add ```LogException``` method to ```ICurrentLogger```  
```csharp
public void LogException(Exception ex)
{
    Log($"ERROR - {ex.GetType()}\n    {ex.Message}");
}
```
* Add ```LogException``` call in ```Program.cs```  
```csharp
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
```
* Build application (build succeeds)
* Run application - default is used
* Try to add ```LogException``` to ```IOldLogger```  
    * Remove ```public``` modifier
    * Compiler error (use C# 8.0 or higher)

### C# 8 Private members on interfaces (must have default implementation)
* Try to add ```private FormatExceptionMessage``` without implementation
```csharp
private string FormatExceptionMessage(Exception ex);
```
* Compiler error
* Extract ```FormatExceptionMessage``` method and add ```private``` modifer  
```csharp
public void LogException(Exception ex)
{
    Log(FormatExceptionMessage(ex));
}

private string FormatExceptionMessage(Exception ex)
{
    return $"ERROR - {ex.GetType()}\n    {ex.Message}";
}
```
**Private interface members must have default implementation**  

### C# 8 Static members in interface (static Main allowed)
* Interfaces can have ```static``` members (just like static members on classes)
* Show ```IEntryPoint.cs```
* Comment out ```Main``` method in ```Program.cs```  
* Build and run  

**Don't see why not**  

## Properties (and other stuff)

RegularPolygon.cs
```csharp
public int NumberOfSides { get; set; };
public int SideLength { get; set; }

public RegularPolygon()
{

}

public RegularPolygon(int numberOfSides, int sideLength)
{
    NumberOfSides = numberOfSides;
    SideLength = sideLength;
}

public int GetPerimeter()
{
    return NumberOfSides * SideLength;
}

private double GetApothem()
{
    return SideLength / (2 * Math.Tan(Math.PI / NumberOfSides));
}

public double GetArea()
{
    return (SideLength * GetApothem() * NumberOfSides) / 2;
}
```
### C# 6 Automatic property initializer

```csharp
public int NumberOfSides { get; set; } = 3;
```

### C# 6 Expression-bodied function members
```csharp
public int GetPerimeter() => NumberOfSides * SideLength;
```
* Use refactoring to update ```GetArea``` and ```GetApothem``` methods  
* Change ```GetPerimeter()``` method to ```Perimeter``` calculated property

```csharp
public int Perimeter
{
    get
    {
        return NumberOfSides * SideLength;
    }
}
```
* Expression-bodied getter
```csharp
public int Perimeter { get => NumberOfSides * SideLength; }
```

* Expression-bodied calculated property
```csharp
public int Perimeter => NumberOfSides * SideLength;
```
**Note that method with expression body and calculated property with method body look very similar**  
```csharp
public int GetPerimeter() => NumberOfSides * SideLength;
public int Perimeter => NumberOfSides * SideLength;
```

### C# 9 Init-only property setter
* Show perils of public setter
```csharp
triangle.NumberOfSides = 5;
```
* private set
```csharp
public int NumberOfSides { get; private set; }
public int SideLength { get; private set; }
```
* Show that parameterized constructor works but the default constructor with object initializer does not

* Change ```private set``` to ```init```  

```csharp
public int NumberOfSides { get; init; }
public int SideLength { get; init; }
```
* Show that default constructor now works

### C# 11 Required members
```csharp
public required int NumberOfSides { get; init; }
```
* Show constructor effects  
    * object initializer without value
    * constructor with parameters (doesn't compile)  

### C# 11 ```SetsRequiredMembers``` attribute
```csharp
[SetsRequiredMembers]
public RegularPolygon(int numberOfSides, int sideLength)
{
    NumberOfSides = numberOfSides;
    SideLength = sideLength;
}
```
* Show constructor effects  
    * constructor with parameters (works)  
* Put ```SetsRequiredMembers``` on default constructor
    * Compiles, but runtime has invalid data

## Nullable & Expressions
### C# 6 ```nameof``` expression
* Look at ```DataParser.cs```  
```csharp
private ICurrentLogger? logger;

public DataParser(ICurrentLogger logger)
{
    if (logger is null)
        throw new ArgumentNullException("logger");
    this.logger = logger;
}
```
* Change ```"logger"``` to ```nameof```  
```csharp
if (logger is null)
    throw new ArgumentNullException(nameof(logger));
this.logger = logger;
```
* Show that renaming ```logger``` cascades the change

### C# 7 Throw expression
* Combine lines into ternary ```?:```  
```csharp
this.logger = logger is not null 
    ? logger 
    : throw new ArgumentNullException(nameof(logger));
```

### C# 8 Null coalescing operator

```csharp
this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
```

### C# 6 Null conditional operator
* Look at ```TryParseInt``` method  

```csharp
int value;
bool success = int.TryParse(input, out value);
if (success)
{
    logger.Log($"Success: parsed {input} as {value}");
    parsedValue = value;
    return true;
}
else
{
    logger.Log($"Failure: could not parse {input}");
    parsedValue = default;
    return false;
}
```
* Look at messages on ```logger``` calls  
* Add null conditional operator
```csharp
logger?.Log($"Success: parsed {input} as {value}");
//...
logger?.Log($"Failure: could not parse {input}");
```

### C# 7 ```out``` variables  
* Before
```csharp
int value;
bool success = int.TryParse(input, out value);
```
* After
```csharp
bool success = int.TryParse(input, out int value);
```

### C# 8 Switch expression
* Switch statement
```csharp
bool success = int.TryParse(input, out int parsedValue);
switch (success)
{
    case true: return (true, parsedValue);
    case false: return (false, default);
}
```

* Switch expression
```csharp
return int.TryParse(input, out int parsedValue) switch
{
    true => (true, parsedValue),
    false => (false, default),
};
```
### C# 9 Nullable reference types
* Back in ```Program.cs```  
```csharp
DataParser parser = new(new ConsoleLogger());
```

* Show that non-null reference types can still be null
```csharp
DataParser parser = new(null);
```

### C# 8 ```notnull``` generic type constraint
* In ```DataParser.cs```  
```csharp
public TResult Parse<TResult>(string input)
```
* Add ```notnull``` generic constraint
```csharp
public TResult Parse<TResult>(string input) where TResult : notnull
```

### C# 7 Discards (and out variables)
* Current code uses out variables  
```csharp
bool success = parser.TryParseInt("123", out int value);
Console.WriteLine($"Output from console: value {value}");

success = parser.TryParseInt("345", out value);
Console.WriteLine($"Output from console: value {value}");

success = parser.TryParseInt("abc", out value);
Console.WriteLine($"Output from console: value {value}");

success = parser.TryParseInt(null, out value);
Console.WriteLine($"Output from console: value {value}");
```

* ```success``` variable is not used, so we can use a discard instead

```csharp
_ = parser.TryParseInt("123", out int value);
Console.WriteLine($"Output from console: value {value}");

_ = parser.TryParseInt("345", out value);
Console.WriteLine($"Output from console: value {value}");

_ = parser.TryParseInt("abc", out value);
Console.WriteLine($"Output from console: value {value}");

_ = parser.TryParseInt(null, out value);
Console.WriteLine($"Output from console: value {value}");
```

## Lambda Expression examples
### C# 9 Lambda expression discard parameters
* Look at ```RunLambdaExpressionSample``` method
```csharp
List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
await Parallel.ForEachAsync(numbers,
    async (currentNumber, cancelToken) =>
    {
        await Task.Delay(1);
        Console.WriteLine($"Number: {currentNumber}");
    });
```
* Run application  
* ```cancelToken``` is not used, so we can replace it with a discard
```csharp
await Parallel.ForEachAsync(numbers,
    async (currentNumber, _) =>
    {
        await Task.Delay(1);
        Console.WriteLine($"Number: {currentNumber}");
    });
```

## Pithy ending to wrap everything up!

---