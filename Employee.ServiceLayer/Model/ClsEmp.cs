using Employee.DBLayer.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Model
{
    public class ClsEmp
    {

        public string EmpName { get;set; }
        public int deparcount {  get; set; }

    }

    public class ClsBMEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDt { get; set; }

        public int departmentid { get; set; }

    }

    public class ClsEmployeeByDepar
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
}
