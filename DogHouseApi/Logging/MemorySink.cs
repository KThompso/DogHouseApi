using System;
using System.Collections.Concurrent;
using System.Linq;
using Serilog.Core;
using Serilog.Events;

namespace DogHouseApi.Logging
{
    public class MemorySink : ILogEventSink
    {
        private static readonly MemorySink _sink = new MemorySink();

        public static int MaxSize = 1000;

        private readonly ConcurrentBag<LogEvent> _logs;

        private MemorySink()
        {
            _logs = new ConcurrentBag<LogEvent>();
        }

        public static MemorySink GetInstance()
        {
            return _sink;
        }

        public void Emit(LogEvent log)
        {
            if (_logs.Count() > MaxSize)
            {
                _logs.Clear();
            }

            _logs.Add(log);
        }

        public IOrderedEnumerable<LogEvent> GetLogs(
            DateTimeOffset start,
            DateTimeOffset end)
        {
            return _logs
                .Where(log =>
                    (log.Timestamp >= start || start == DateTimeOffset.MinValue)
                    && (log.Timestamp <= end || end == DateTimeOffset.MinValue))
                .OrderBy(log => log.Timestamp);
        }

    }
}