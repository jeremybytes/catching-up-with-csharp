namespace net80_library;

public interface ICurrentLogger
{
    // C# 8 Access modifiers (public)
    public void Log(string message);

    // C# 8 Default implementation
    public void LogException(Exception ex)
    {
        Log(FormatExceptionMessage(ex));
    }

    // C# 8 Access modifiers (private)
    //   Private members must have default implementation
    private string FormatExceptionMessage(Exception ex)
    {
        return $"ERROR - {ex.GetType()}\n    {ex.Message}";
    }
}
