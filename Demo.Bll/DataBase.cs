using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll
{
    public class DataBase : IDisposable
    {
        private readonly string connstring = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        private OracleConnection conn;
        private OracleConnection Conn
        {
            get
            {
                if (conn == null || conn.State == System.Data.ConnectionState.Closed)
                {
                    conn = new OracleConnection(connstring);

                        conn.Open();

                }
                return conn;
            }
        }
        public OracleConnection CreateDataBase()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return Conn;
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
