using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.AdminSystem
{
    public class Log
    {
        public static void LogMessage(LogEntryType logEntryType, LogSeverity logSeverity, string heading,
            string description, Exception exception)
        {
            MongoDbInstance.GetMongoCollection<LogEntry>("SSOSyncUtility", "Log").InsertOneAsync(new LogEntry
            {
                LogEntryType = logEntryType,
                LogSeverity = logSeverity,
                Heading = heading,
                Description = description,
                CreateDateTime = DateTime.Now,
                Exception = exception
            });
        }

        public static void LogError(string heading, string description, Exception exception = null)
        {
            LogMessage(LogEntryType.Error, LogSeverity.None, heading, description, exception);
        }

        public static void LogDebug(string heading, string description, Exception exception = null)
        {
            LogMessage(LogEntryType.Info, LogSeverity.Debug, heading, description, exception);
        }
    }
}