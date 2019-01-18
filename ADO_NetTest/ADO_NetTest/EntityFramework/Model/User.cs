using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ADO_NetTest.EntityFramework.Model.Enum;

namespace ADO_NetTest.EntityFramework.Model
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(50)]
        public string DisplayName { get; set; }

        public EnumCountry Country { get; set; }

        public DateTime? AddTime { get; set; }

        //导航属性
        public virtual List<Comment> Comments { get; set; }
    }
}