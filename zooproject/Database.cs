using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace zooproject
{
    public class Database
    {
        string _connection_string;
        private SqlConnection conn;

        public Database(string connection_string)
        {
            _connection_string = connection_string;
        }
        public SqlConnection Connection
        {
            get { return conn; }
        }

        public void connect()
        {
            conn = new SqlConnection(_connection_string);
            conn.Open();
        }

        public void disconnect()
        {
            conn.Close();
        }
    }
}
