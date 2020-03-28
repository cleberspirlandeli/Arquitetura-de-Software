using System;

namespace DesignPatterns
{
    public interface ILogger
    {
        void Log(string message);
        void LogError(Exception exception);
    }
}