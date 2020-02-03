using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"LAPTOP-9IA4VKBD";

            string database = "capteur";
            string username = "toto";
            string password = "azerty";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

}
