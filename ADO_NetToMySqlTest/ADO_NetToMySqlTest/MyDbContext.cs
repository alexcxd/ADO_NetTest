using System.Data.Entity;
using ADO_NetToMySqlTest.Model;
using MySql.Data.Entity;

namespace ADO_NetToMySqlTest
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(m => m.DisplayName)
                .HasColumnName("display_name");
        }
    }
}