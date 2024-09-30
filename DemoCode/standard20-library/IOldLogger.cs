using System;

namespace standard20_library
{
    // C# 7.3 and earlier
    public interface IOldLogger
    {
        // No access modifiers
        void Log(string message);
        // No default implementation
        void LogException(Exception ex);
    }
}
