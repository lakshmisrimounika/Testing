using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace JobPortalLib.Helper
{
    public class LogFile
    {
        /// <summary>
        /// This method is useful for Log the user request.
        /// </summary>
        /// <param name="logEntry">object of log entry</param>
        public static void Write(ILogEntry logEntry)
        {
            string _ErrorMsg = string.Empty;
            try
            {
                //string filepath = @".\JobPortal\Upload\TestLog";
                ////.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
                //StreamWriter sw = new StreamWriter(filepath , true);
                //sw.WriteLine("Page Name = "+logEntry.PageName);
                //sw.WriteLine("Method Name = " + logEntry.MethodName);
                //sw.WriteLine("Action = " + logEntry.Action);
                //sw.WriteLine("Input Data = " + logEntry.InputData);
                //CultureInfo cultureInfo = new CultureInfo("en-IN");
                //sw.WriteLine("Log DateTime = " +Convert.ToDateTime(DateTime.UtcNow.AddHours(5.3),cultureInfo));               
                //sw.Flush();
                //sw.Close();
            }
            catch (Exception ex)
            {
                _ErrorMsg = ex.Message.ToString();
            }
        }
    }
}
