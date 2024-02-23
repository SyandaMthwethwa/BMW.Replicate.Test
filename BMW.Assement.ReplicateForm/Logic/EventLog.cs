using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Assessment.ReplicateForm.Logic
{

    public class EventLog
    {

 
        public void Log(string message, StringBuilder logBuilder)
        {
            int mess = message.Length;
            if(logBuilder.Length != mess)
            {
                logBuilder.AppendLine(message);
            }
            
        }

        public void ViewLogs(string logFilePath, StringBuilder logBuilder)
        {
            File.WriteAllText(logFilePath, logBuilder.ToString());
            System.Diagnostics.Process.Start("notepad.exe", logFilePath);
        }
    }
}
