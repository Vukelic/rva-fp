using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class LoggerTable
    {
        public static BindingList<string> Logs { get; set; } = new BindingList<string>();

        public static void AddLog(string log, TypeEventLog typeevent, DateTime datetime)
        {
            string l = datetime.ToString() + " " + typeevent.ToString() + " " + log;
            Logs.Add(l);
            LogManager.GetLogger("Client").Debug(log);
        }
    }
}
