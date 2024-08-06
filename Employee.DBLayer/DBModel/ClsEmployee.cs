using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBLayer.DBModel
{
    [Table("mstEmployee")]
    public class ClsEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public bool IsActive { get;set; }
        public DateTime CreatedDt { get; set; }

        public int departmentid { get; set; }   
        public ClsDepartment clsDepartment { get; set; }

    }
}
