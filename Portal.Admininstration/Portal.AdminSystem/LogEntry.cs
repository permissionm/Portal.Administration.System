using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.AdminSystem
{
    public class LogEntry
    {
        public DateTime CreateDateTime { get; set; }
        public LogEntryType LogEntryType { get; set; }
        public LogSeverity LogSeverity { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public Exception Exception { get; set; }
    }
}
