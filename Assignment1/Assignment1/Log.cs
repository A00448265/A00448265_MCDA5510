using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Log
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public Log()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
        /// <summary>
        /// File based Info Logging 
        /// </summary>
        /// <param name="sMessage"></param>
        public void WriteInfoLog(string sMessage)
        {
            try
            {
                log.Info(sMessage);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// File based Error Logging 
        /// </summary>
        /// <param name="sMessage"></param
        public void WriteErrorLog(string sMessage)
        {
            try
            {
                log.Error(sMessage);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
