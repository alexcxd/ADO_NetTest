using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ADO_NetTest.Ado
{
    public class AdoConnection
    {

        //创建command对象      
        private MySqlCommand cmdMysql = null;
        //创建connection连接对象  
        private static MySqlConnection connMysql = null;
        public static void AdoConnectionMain()
        {
            //数据库连接字符串  
            String connstrMysql = "server=47.106.249.107;Database =test;uid=root;pwd=123456;charset=utf8";
           
            //建立数据库连接  
            connMysql = new MySqlConnection(connstrMysql);

            String connstrSqlServer = "Server=HERO-20150715KW;Database=TSQL2012;Integrated Security=SSPI;";
            SqlConnection connSqlServer = new SqlConnection(connstrSqlServer);
            connSqlServer.Open();
            SqlCommand command = new SqlCommand("Select * From Employees", connSqlServer);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
            }
            connSqlServer.Close();
            Console.ReadKey();

        }
    }
}