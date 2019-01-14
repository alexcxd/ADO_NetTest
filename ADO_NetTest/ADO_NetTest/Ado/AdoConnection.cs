using System;
using MySql.Data.MySqlClient;

namespace ADO_NetTest.Ado
{
    public class AdoConnection
    {

        //创建command对象      
        private MySqlCommand cmd = null;
        //创建connection连接对象  
        private static MySqlConnection conn = null;
        public static void AdoConnectionMain()
        {
            //数据库连接字符串  
            String connstr = "server=47.106.249.107;Database =test;uid=root;pwd=123456;charset=utf8";
            //建立数据库连接  
            conn = new MySqlConnection(connstr);
        }
    }
}