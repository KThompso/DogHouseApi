using Serilog;
using Serilog.Configuration;

namespace DogHouseApi.Logging
{
    public static class SerilogExtensions
    {
        public static LoggerConfiguration Memory(
            this LoggerSinkConfiguration loggerConfiguration, int maxSize)
        {
            MemorySink.MaxSize = maxSize;
            return loggerConfiguration.Sink(MemorySink.GetInstance());
        }
    }
}