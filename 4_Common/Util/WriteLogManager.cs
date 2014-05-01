using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki.Common.Util
{

    public static class WriteLogManager
    {

        public static bool WriteLogLogic(string message)
        {
            try
            {
                WriteLogEntry(message, System.Diagnostics.EventLogEntryType.Error, "Logic");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteLogFrontEnd(string message)
        {
            try
            {
                WriteLogEntry(message, System.Diagnostics.EventLogEntryType.Error, "FrontEnd");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void WriteLogEntry(string message, System.Diagnostics.EventLogEntryType entryType, string eventLogSource)
        {
            System.Diagnostics.EventLog.WriteEntry("WIKI-" + eventLogSource, message, entryType, 5099);
        }

    }
}
