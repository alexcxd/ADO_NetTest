using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using MySql.Data.Entity;

namespace ADO_NetTest.EntityFramework
{
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetExecutionStrategy("MySql.Data.Entity.MySqlEFConfiguration", () => new MySqlExecutionStrategy());
        }
    }
}