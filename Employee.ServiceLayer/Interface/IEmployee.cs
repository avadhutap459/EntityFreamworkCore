using Employee.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Interface
{
    public interface IEmployee
    {
        List<ClsEmp> GetEmpCountBaseOnDepartment();

        List<ClsEmp> GetEmpCountBaseOnDepartmentUsingSP();

        List<ClsBMEmployee> GetEmpDetailBaseOnDeparId(int DepartId);

        ClsBMEmployee GetEmpDetailsBaseEmpId(int EmpId);
        int InsertuserData(ClsCurrentUserInterface request);
        bool Login(ClsLoginRequestInterface reques);
    }
}
