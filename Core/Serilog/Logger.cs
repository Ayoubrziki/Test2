using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Serilog
{
    public static class Logger
    {
        private static readonly ILogger _logger = Log.ForContext(typeof(Logger));

        public static void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        public static void Info(string message, params object[] args)
        {
            _logger.Information(message, args);
        }

        public static void Warn(string message, params object[] args)
        {
            _logger.Warning(message, args);
        }

        public static void Error(Exception exception, string message, params object[] args)
        {
            _logger.Error(exception, message, args);
        }
    }
}
