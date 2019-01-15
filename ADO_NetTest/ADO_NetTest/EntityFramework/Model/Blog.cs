using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADO_NetTest.EntityFramework.Model
{
 /**
 *  1.排除类型，使用NotMapped属性或DbModelBuilder.Ignore fluent API。
 *  2.主要密钥约定,否一个类上的属性名为"ID"（不区分大小写），或类名后, 跟"ID"。 
 *  3.关系约定：
 *      1)导航属性提供一种导航两个实体类型之间的关系方法
 *      2)建议您包括表示依赖对象的类型上的外键属性
 *      3）外键不可为 null，则第一个代码设置级联删除的关系。 
 *         如果依赖实体的外键是可以为 null，Code First 不会设置级联删除的关系，并且当删除主体将设置外键为 null。
 * 
 */
    public class Blog
    {
        public int BlogId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        public DateTime AddTime { get; set; }


        //导航属性
        public virtual List<Post> Posts { get; set; }
    }
}