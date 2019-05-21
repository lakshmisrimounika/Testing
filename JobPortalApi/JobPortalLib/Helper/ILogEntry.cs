using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortalLib.Helper
{
    public interface ILogEntry
    {
        string PageName { get; set; }
        string MethodName { get; set; }
        string Action { get; set; }
        string InputData { get; set; }
        string LogDateTime { get; set; }
    }
}
