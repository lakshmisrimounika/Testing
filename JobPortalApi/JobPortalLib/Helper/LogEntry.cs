using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortalLib.Helper
{
    public class LogEntry:ILogEntry
    {
        public string PageName { get; set; }
        public string MethodName { get; set; }
        public string Action { get; set; }
        public string InputData { get; set; }
        public string LogDateTime { get; set; }
        
    }
}
