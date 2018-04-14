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

        //"Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI"
        public Database(string connection_string)
        {
            //_connection_string = connection_string;
            _connection_string = "Data Source=(local);Initial Catalog=Zoo;Integrated Security=SSPI";
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
