using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBLayer.DBModel
{
    [Table("mstDepartment")]
    public class ClsDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentid { get; set; }

        public string departmentname { get; set; }

        public ICollection<ClsEmployee> employees { get; set; }
    }
}
