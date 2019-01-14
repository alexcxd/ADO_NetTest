using System;
using System.ComponentModel.DataAnnotations;

namespace ADO_NetTest.EntityFramework.Model
{
    public class Post
    {
        public int PostId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public DateTime AddTime { get; set; }

        //外键属性
        public int BlogId { get; set; }

        //导航属性
        public virtual Blog Blog { get; set; }
    }
}