using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetTest.EntityFramework.Model.TSQL
{
    public class Order
    {
        public int OrderId { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(10)]
        public string CustId { get; set; }

        public DateTime Orders { get; set; }

        public int Qty { get; set; }

    }
}
