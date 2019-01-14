using ADO_NetTest.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_NetTest.Ado;

namespace ADO_NetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EfCodeFirstToNew.EF_CodeFirstToNewMain();
            //AdoConnection.AdoConnectionMain();
        }
    }
}
