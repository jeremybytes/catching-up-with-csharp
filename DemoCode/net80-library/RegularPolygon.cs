using System.Diagnostics.CodeAnalysis;

namespace PropertyFeatures;

public class RegularPolygon
{
    // C# 6 Automatic property initializer
    //public int NumberOfSides { get; set; } = 3;
    //public int SideLength { get; set; }

    // C# 9 init-only setter
    //public int NumberOfSides { get; private set; }
    //public int SideLength { get; private set; }
    //public int NumberOfSides { get; init; }
    //public int SideLength { get; init; }

    // C# 11 required members
    public required int NumberOfSides { get; init; }
    public int SideLength { get; init; }

    // C# 6 Expression-bodied members
    //public int GetPerimeter()
    //{
    //    return NumberOfSides * SideLength;
    //}
    public int GetPerimeter() => NumberOfSides * SideLength;
    
    // C# 6 Expression-bodied getter for calculated properties
    //public int Perimeter
    //{
    //    get
    //    {
    //        return NumberOfSides * SideLength;
    //    }
    //}
    //public int Perimeter
    //{
    //    get => NumberOfSides * SideLength;
    //}
    // C# 6 Expression-bodied calculated properties
    public int Perimeter => NumberOfSides * SideLength;

    // C# 6 Expression-bodied members
    public double GetArea() =>
        (SideLength * GetApothem() * NumberOfSides) / 2;
    private double GetApothem() =>
        SideLength / (2 * Math.Tan(Math.PI / NumberOfSides));

    public RegularPolygon()
    {

    }

    // C# 11 SetsRequiredMembers attribute
    [SetsRequiredMembers]
    public RegularPolygon(int numberOfSides, int sideLength)
    {
        NumberOfSides = numberOfSides;
        SideLength = sideLength;
    }

}
