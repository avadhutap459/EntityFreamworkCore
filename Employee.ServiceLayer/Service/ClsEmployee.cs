using Employee.DBLayer.DBModel;
using Employee.DBLayer.Migrations;
using Employee.ServiceLayer.EF.Interface;
using Employee.ServiceLayer.Interface;
using Employee.ServiceLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Service
{
    public class ClsEmployee : IEmployee
    {
        public IUnitOfWork _unitOfWork;
        public ClsEmployee(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        ~ClsEmployee()
        {
            Dispose(false);
        }


        public List<ClsEmp> GetEmpCountBaseOnDepartment()
        {

            List<ClsEmp> objemp = (from emp in _unitOfWork.dbContext.Employees
                                    join dep in _unitOfWork.dbContext.Department
                                    on emp.departmentid equals dep.departmentid into depar
                                    from de in depar.DefaultIfEmpty()
                                    group de by new { emp.EmployeeName, emp.EmployeeId } into groupdep
                                   where groupdep.Count() > 1                                 
                                    select new ClsEmp
                                    {
                                        EmpName =  groupdep.Key.EmployeeName
                                        ,
                                        deparcount= groupdep.Count()

                                    }).ToList();

            return objemp;

        }
        public List<ClsEmp> GetEmpCountBaseOnDepartmentUsingSP()
        {

            var objemp = _unitOfWork.dbContext.Set<ClsEmpCountBaseDep>()
                .FromSqlRaw("SP_GetEmployeeCountBaseOnDepartment").ToList().AsQueryable();

            List<ClsEmp> lstemp = objemp.Select(x => new ClsEmp
            {
                EmpName = x.EmployeeName,
                deparcount = x.Count
            }).ToList();

            return lstemp;         
        }

        public List<ClsBMEmployee> GetEmpDetailBaseOnDeparId(int DepartId)
        {
            var _params = new SqlParameter("deparId", DepartId);

            var lstempbydeprid = _unitOfWork.dbContext.Employees.FromSqlRaw($"EXEC SP_GetEmployeeBaseOnDeparId @deparId", _params).ToList().AsQueryable();

            List<ClsBMEmployee> lstemployee = lstempbydeprid.Select(x => new ClsBMEmployee
            {
                EmployeeId = x.EmployeeId,
                EmployeeName = x.EmployeeName,
                IsActive = x.IsActive,
                CreatedDt = x.CreatedDt,
                departmentid = x.departmentid
            }).ToList();

            return lstemployee;
        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) 
            {
                if (disposing) 
                { 
                    
                }
                else
                {

                }

                disposedValue = true;
            }
            else
            {

            }
        }

        public void Dispose() 
        {
            Dispose(false);

            GC.SuppressFinalize(this);
        }
    }
}
