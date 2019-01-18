using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ADO_NetTest.EntityFramework.Model;

namespace ADO_NetTest.EntityFramework.Service
{
    public class BlogService : IDisposable
    {
        public void AddBlogToPost()
        {
            var posts = new List<Post>();

            posts.Add(new Post
            {
                AddTime = DateTime.Now,
                Content = "111",
                PageNum = 2,
                Title = "1"
            });

            var blog = new Blog
            {
                AddTime = DateTime.Now,
                Name = "Test1",
                Url = "127.0.0.1",
                Posts = posts
            };

            //添加过程中会将Post也添加
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }

        public void GetBlogToAddPost()
        {
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Single(m => m.BlogId == 1);

                blog.Posts.Add(new Post
                {
                    AddTime = DateTime.Now,
                    Content = "333",
                    PageNum = 2,
                    Title = "3"
                });

                db.Blogs.AddOrUpdate(blog);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}