using System;
using System.ComponentModel.DataAnnotations;

namespace ADO_NetTest.EntityFramework.Model
{
    public class Comment
    {
        public int CommentId { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        public DateTime AddTime { get; set; }

        public int UserId { get; set; }

        //外键属性
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}