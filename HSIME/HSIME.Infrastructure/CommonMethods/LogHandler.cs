using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSIME.Infrastructure.CommonMethods
{
    public class LogHandler
    {
        private static Logger logger = null;
        public static Logger LoggerInstance()
        {
            return logger = LogManager.GetCurrentClassLogger();
        }
    }
}
