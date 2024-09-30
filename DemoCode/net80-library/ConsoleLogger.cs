namespace net80_library;

public class ConsoleLogger : ICurrentLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now:u}: {message}");
    }
}
