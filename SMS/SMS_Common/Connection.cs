using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SMS_Common
{
    public class Connection
    {
        public static string dbConnection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    }
}
