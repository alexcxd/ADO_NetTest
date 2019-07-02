using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADO_NetToMySqlTest.Model
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

        public virtual List<Comment> Comments { get; set; }
    }
}