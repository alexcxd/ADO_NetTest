using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetTest.EntityFramework.Model.TSQL
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public int MarId { get; set; }

        [Required]
        [StringLength(20)]
        public string Ssn { get; set; }

        [Column("Salary", TypeName = "Money")]
        public decimal Salary { get; set; }
    }
}
