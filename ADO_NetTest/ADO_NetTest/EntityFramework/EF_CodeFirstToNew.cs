using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_NetTest.EntityFramework.Model;
using ADO_NetTest.EntityFramework.Model.Enum;

/*
 *  我的数据位于何处？
 *  1.如果本地 SQL Express 实例不可用 （默认情况下使用 Visual Studio 2010 安装） 然后代码优先已创建了数据库在该实例上
 *  2.如果 SQL Express 不可用，则 Code First 将尝试并使用LocalDB （默认情况下使用 Visual Studio 2012 安装）
 *  3.派生上下文中，在本例中是完全限定名称命名数据库CodeFirstNewDatabaseSample.BloggingContext
 *  
 *  处理模型更改
 *  1.Enable-Migrations 生成Migrations文件夹下相关的内容，仅第一次时使用
 *      1)Configuration.cs：此文件包含迁移将用于迁移的设置 bloggingcontext。
 *      2)<时间戳>_InitialCreate.cs 这是你第一次迁移，它表示已应用到数据库
 *      3)– EnableAutomaticMigrations用于自动迁移的切换
 *      4)InitialCreate – IgnoreChanges 创建空迁移，它只是将_ _MigrationsHistory 表加入数据库
 *  2.Add-migration [Name] 检查自上次迁移以来的更改和搭建基架以新的迁移与所发现的任何更改。
 *    即生成脚本，并在下一步运行
 *      1)可以用于修改字段约束、添加删除字段
 *      2)可用与创建删除表
 *  3.Update-database 更新数据库
 *      1)–Verbose 查看正在运行的sql
 *  
 *  4.Fluent API 是指定数据批注可以做另外一些更高级的配置不可能的数据注释的一切内容的模型配置的更高级的方法。
 *  
 *  5.自动迁移和手动迁移 两者的根本区别是自动迁移不需要输入Add-migration [Name]生成脚本
 *  
 *  6.延迟加载和
 */
namespace ADO_NetTest.EntityFramework
{
    
    class EfCodeFirstToNew
    {
        public static void EF_CodeFirstToNewMain()
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                var user = new User
                {
                    Name = "cxd",
                    DisplayName = "alex",
                    Country = EnumCountry.Canada
                };
                db.Users.Add(user);
                db.SaveChanges();

                //默认懒惰加载，每一条数据都会访问一次数据库
                var query = from b in db.Users
                    orderby b.Name
                    select b;
                var result = db.Users.Where(m => m.Country == EnumCountry.Canada);

                Console.Write(@"姓名|");
                Console.Write(@"显示名|");
                Console.WriteLine(@"国家|");
                foreach (var item in query)
                {
                    Console.Write(item.Name + @"|");
                    Console.Write(item.DisplayName + @"|");
                    Console.WriteLine(item.Country + @"|");
                }
                Console.ReadKey();
            }
        }
    }
}

/**
 *  实体 Model中
 *  1.排除类型，使用NotMapped属性或DbModelBuilder.Ignore fluent API。
 *  2.主要密钥约定,否一个类上的属性名为"ID"（不区分大小写），或类名后, 跟"ID"。 
 *  3.关系约定：
 *      1)导航属性提供一种导航两个实体类型之间的关系方法
 *      2)建议您包括表示依赖对象的类型上的外键属性
 *      3）外键不可为 null，则第一个代码设置级联删除的关系。 
 *         如果依赖实体的外键是可以为 null，Code First 不会设置级联删除的关系，并且当删除主体将设置外键为 null。
 *  4.枚举：默认情况下，枚举属于int类型 见Model/User
 */





//创建上下文,代表与数据库的会话，以保证查询和保存数据
[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class BloggingContext : DbContext
{
    public BloggingContext() : base("DefaultConnection")
    {   
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    //Fluent API
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(m => m.DisplayName)
            .HasColumnName("display_name");
    }
}
