# Catching Up with C#: What You may Have Missed
C# has been changing rapidly over the last several years. You may have heard of some of the items like tuples, string interpolation, and nullable reference types. But how many of the 100 changes (starting with C# 6) do you actually know? We'll take a closer look at 19 of the changes that are most important to your code, including nameof, discards, pattern matching, expression-bodied members, various null operators, and auto-property updates. And of course, there will be resources to see the rest of the updates.  

Code samples (.NET 8) and slides are included in this repository.  

> Note: The list of included features will seem a bit arbitrary. I did not include many of the features that have been well-advertised (but that definition depends on your news sources). Many of these are things I find useful. Some of them are "it doesn't work the way I expected". This is not a complete list of C# feature updates.  

## Project Layout
To build and run the code, you will need to have .NET 8 installed on your machine. The demo is a console application, and it will run cross-platform.  

The /DemoCode folder has the source code which has 3 projects.

**/console-app** is the console application to kick off the samples.  

**/net80-library** contains the shared classes and interfaces used in the console application. This is a .NET 8 library project.  

**/standard20-library** contains a sample interface from before C# 8. This is a .NET Standard 2.0 library project.  

To run the code, you can comment/uncomment the various sections in the ```Main``` method in the ```Program.cs``` file.  

```csharp
static async Task Main(string[] args)
{
    await Task.Delay(1);
    RunInterfaceSamples();
    //RunPropertySamples();
    //RunNullableAndExpressionSamples();
    //await RunLambdaExpressionSamples();
}
```

Each of these methods is also in the ```Program.cs``` file.  

## Sample Code
The demo code projects contain the finished code along with commented-out "prior" versions. Here is a sample:  

```csharp
    // C# 6 Expression-bodied function members
    //public int GetPerimeter()
    //{
    //    return NumberOfSides * SideLength;
    //}
    public int GetPerimeter() => NumberOfSides * SideLength;
```

The comment notes that expression-bodied members were added in C# 6. The commented-out code shows the block-bodied syntax, while the last line shows the expression-bodied syntax.  

### List of C# Features Covered  
Here is a list of the C# features that are covered (in order of the live demo, not necessarily the order they appear in the code).  

* C# 8 Access modifiers on interface members  
* C# 8 Default interface member implementation  
* C# 8 Private members on interfaces (must have default implementation)  
* C# 8 Static members in interface (static Main allowed)  
* C# 6 Automatic property initializer  
* C# 6 Expression-bodied function members  
* C# 9 Init-only property setter  
* C# 11 Required members  
* C# 11 ```SetsRequiredMembers``` attribute  
* C# 6 ```nameof``` expression  
* C# 7 Throw expression  
* C# 8 Null coalescing operator  
* C# 6 Null conditional operator  
* C# 7 ```out``` variables  
* C# 8 Switch expression  
* C# 9 Nullable reference types  
* C# 8 ```notnull``` generic type constraint  
* C# 7 Discards  
* C# 9 Lambda expression discard parameters

## Resources  

**Microsoft Learn**  
* [C# Version History](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-60)  
Note: This link jumps with C# 6. Scroll up to see other versions.

**Additional Materials (and articles written by me)**  
*Interfaces*  
* [Catching Up with C# Interfaces](https://github.com/jeremybytes/csharp11-interfaces)  
Session materials that dive into the various changes to interfaces in C# 8 and C# 11.  
* [C# 8 Interfaces: Public, Private, and Protected Members](https://jeremybytes.blogspot.com/2019/11/c-8-interfaces-public-private-and.html)  
* [C# 8 Interfaces: Static Members](https://jeremybytes.blogspot.com/2019/12/c-8-interfaces-static-members.html)  
* [C# 8 Interfaces: Static Main -- Why Not?](https://jeremybytes.blogspot.com/2019/12/c-8-interfaces-static-main-why-not.html)  
* [Misusing C#: Multiple Main() Methods](https://jeremybytes.blogspot.com/2020/06/misusing-c-multiple-main-methods.html)  

*Nullability*  
* Video: [Nullable Reference Types and Null Operators in C#](https://www.youtube.com/watch?v=xRxcfSyMD6Y)  
* [Nullability in C# - What it is and What it is Not](https://jeremybytes.blogspot.com/2022/07/nullability-in-c-what-it-is-and-what-it.html)  
* [Null Conditional Operators in C# - ?. and ?[]](https://jeremybytes.blogspot.com/2022/07/null-conditional-operators-in-c-and.html)  
* [Null Forgiving Operator in C# - !](https://jeremybytes.blogspot.com/2022/07/null-forgiving-operator-in-c.html)  
* [Null Coalescing Operators in C# - ?? and ??=](https://jeremybytes.blogspot.com/2022/07/null-coalescing-operators-in-c-and.html)  
* [C# "var" with a Reference Type is Always Nullable](https://jeremybytes.blogspot.com/2023/02/c-var-with-reference-types-is-always.html)  

---