using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using ADO_NetTest.EntityFramework.Model;

namespace ADO_NetTest.EntityFramework.Service
{
    public class QueryService
    {
        /// <summary>
        /// 贪婪加载
        /// </summary>
        public void EagerlyLoading()
        {
            //通过ToList实现
            using (var db = new BloggingContext())
            {
                //加载所有的Blog和它相关的Post，使用string明确关系
                var blog1 = db.Blogs
                              .Include("Posts")
                              .ToList();

                //加载一个的Blog和它相关的Post，使用string明确关系
                var blog2 = db.Blogs
                              .Where(m => m.BlogId == 1)
                              .Include("Posts")
                              .ToList();
                
                //加载一个的Blog和它相关的Post，使用string明确关系
                var blog5 = db.Blogs
                              .Include("Posts.Comments")
                              .ToList();

                //加载所有的Blog和它相关的Post，使用lambda明确关系
                var blog3 = db.Blogs
                              .Include(m => m.Posts)
                              .ToList();

                //加载一个的Blog和它相关的Post，使用lambda明确关系
                var blog4 = db.Blogs
                              .Where(m => m.BlogId == 1)
                              .Include(m => m.Posts)
                              .ToList();
                
                //加载一个的Blog和它相关的Post，使用lambda明确关系
                var blog6 = db.Blogs
                              .Include(m => m.Posts.Select(n => n.Comments))
                              .ToList();

                //加载所有的Blog和它相关的Post，关系被默认明确了
                var blog7 = db.Blogs.ToList();
            }
        }

        /// <summary>
        /// 延迟加载
        /// </summary>
        public void LazyLoaging()
        {
            using (var db = new BloggingContext())
            {
                var sw = new Stopwatch();
                sw.Start();
                var blog1 = db.Blogs
                    .Include(m => m.Posts.Select(n => n.Comments));
                sw.Stop();
                var time = sw.ElapsedMilliseconds;
                foreach (var blog in blog1)
                {
                    foreach (var blogPost in blog.Posts)
                    {
                        foreach (var blogPostComment in blogPost.Comments)
                        {
                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 显式加载
        /// </summary>
        public void ExplicitlyLoaging()
        {
            //这里有个细节，当第一次的post加载了Blog后，第二次查找的blog是上一次加载的blog，那么ef会直接取用包括关系
            //第二次查找的blog是上一次加载的blog，那么ef会直接取用包括关系，这次加载的post时会加入而不是覆盖
            using (var db = new BloggingContext())
            {
                var post = db.Posts.Find(3);

                // 通过post加载blog
                db.Entry(post).Reference(p => p.Blog).Load();

                db.Entry(post).Reference("Blog").Load();


                var blog = db.Blogs.Find(1);

                // 通过blog加载指定的post
                db.Entry(blog)
                    .Collection(b => b.Posts)
                    .Query()
                    .Where(p => p.Content.Contains("entity-framework"))
                    .Load();
 
                db.Entry(blog)
                    .Collection<Post>("Posts")
                    .Query()
                    .Where(p => p.Content.Contains("entity-framework"))
                    .Load();
            }
        }
    }
}