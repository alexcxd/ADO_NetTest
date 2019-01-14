using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ADO_NetTest
{
    public class DbUtils
    {
        private string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private List<MySqlConnection> pool = new List<MySqlConnection>();

        public void Init(int poolSize)
        {
            while (poolSize-- > 0)
            {
                var conn = new MySqlConnection(conStr);
                pool.Add(conn);
            }
        }
    }
}