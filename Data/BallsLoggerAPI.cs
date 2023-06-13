using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Text;

namespace Data
{
    public abstract class BallsLoggerAPI
    {
        public static BallsLoggerAPI CreateBallsLoggerAPI()
        {   
            return new BallsLogger();
        }
        public abstract void Log(string message);
        public abstract void Start();
        public abstract void Dispose();

    }

    internal class BallsLogger : BallsLoggerAPI
    {
        private readonly StreamWriter _fileWriter;
        private Timer? _timer;
        private readonly ConcurrentQueue<LogMessage> _logs = new();

        public BallsLogger() {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Log.txt";
            try
            {
                _fileWriter = new StreamWriter(path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Log(string message)
        {
            var logMessage = new LogMessage()
            {
                Message = message,
                Time = DateTime.Now
            };

            _logs.Enqueue(logMessage);
        }

        public override void Start()
        {
            _timer = new Timer((state) => EmptyLogQueue(state), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

        private async Task EmptyLogQueue(object? _)
        {
            if (_logs.TryDequeue(out var logMessage))
            {
                await Task.WhenAll(WriteLogMessage(logMessage));
            }
        }

        private async Task WriteLogMessage(LogMessage logMessage)
        {
            var builder = new StringBuilder();
            builder.Append($"| {logMessage.Time} |");
            builder.Append($"| {logMessage.Message} ");
            await _fileWriter.WriteLineAsync(builder.ToString());
            _fileWriter.Flush();
        }

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }

    internal class LogMessage
    {
        public DateTime Time { get; set; }
        public string Message { get; set; } = null!;
    }
}
