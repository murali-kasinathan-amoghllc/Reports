using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AmoghReports.Service
{
    public class DatabaseTools
    {
        public static string getSystemConnString()
        {
            string host = "localhost";
            string db_name = "amoghapps";
            string user_id = "amoghapps";
            string db_pwd = "ipms.admin";

            string my_conn_str = String.Format("user id={0};password={1};" +
                    "data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                    "(HOST={2})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={3})))",
                    user_id,
                    db_pwd,
                    host,
                    db_name);
            return my_conn_str;
        }


        public static string AmgDbConnectionString(int proj_id)
        {
            var sql = "SELECT * FROM PROJECTS WHERE PROJECT_ID=" + proj_id.ToString();
            string database_name = string.Empty;
            string user_name = string.Empty;
            string server_ip = string.Empty;
            string database_pwd = string.Empty;
            string systemConnStr = getSystemConnString();

            using (OracleConnection conn = new OracleConnection(systemConnStr))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                using (OracleCommand cmd_pj = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader dr = cmd_pj.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            database_name = dr["DATABASE_NAME"].ToString();
                            user_name = dr["DB_USER"].ToString();
                            server_ip = dr["HOST_IP"].ToString();
                            database_pwd = dr["DB_PASSWORD"].ToString();
                            break;
                        }
                    }
                }
            }

            if (database_name == string.Empty)
            {
                return null;
            }

            string my_conn_str =
                    $"user id={user_name};password={database_pwd};" +
                    $"data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                    $"(HOST={server_ip})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={database_name})))";

            return my_conn_str;
        }

        
        public static bool ColumnExists(IDataReader reader, string columnName)
        {
            DataRow[] rows = reader.GetSchemaTable().Select(string.Format("ColumnName = '{0}'", columnName));
            return rows.Length > 0;
        }
        


    }
}