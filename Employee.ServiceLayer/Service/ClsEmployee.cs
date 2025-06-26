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


        public ClsBMEmployee GetEmpDetailsBaseEmpId(int EmpId)
        {
            try
            {
                ClsBMEmployee objempdetails = _unitOfWork.dbContext.Employees.Where(x=>x.EmployeeId == EmpId).Select(x=> new ClsBMEmployee
                {
                    EmployeeId = x.EmployeeId,
                    EmployeeName = x.EmployeeName,
                    IsActive = x.IsActive,
                    CreatedDt = x.CreatedDt,
                    departmentid=x.departmentid
                }).FirstOrDefault();

                return objempdetails;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<ClsEmployeeByDepar> GetEmpNameWithDeparName()
        {
            try
            {
                List<ClsEmployeeByDepar> lstEmp = _unitOfWork.dbContext.Employees
                    .GroupJoin(_unitOfWork.dbContext.Department,
                                emp => emp.departmentid,
                                depar => depar.departmentid,
                                (e, d) => new { employee = e, department = d })
                    .SelectMany(x => x.department.DefaultIfEmpty(),
                                (y, z) => new ClsEmployeeByDepar
                                {
                                    EmployeeName = y.employee.EmployeeName,
                                    DepartmentName = z.departmentname
                                }).ToList();
                return lstEmp;
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public List<ClsEmp> GetEmpCountBaseOnDepartment()
        {

            List<ClsEmp> objemp = (from emp in _unitOfWork.dbContext.Employees
                                    join dep in _unitOfWork.dbContext.Department
                                    on emp.departmentid equals dep.departmentid into depar
                                    from de in depar.DefaultIfEmpty()
                                    group de by new { emp.EmployeeName } into groupdep
                                   where groupdep.Count() > 1                                 
                                    select new ClsEmp
                                    {
                                        EmpName =  groupdep.Key.EmployeeName,
                                        deparcount= groupdep.Count()

                                    }).ToList();

            List<ClsEmp> objemp1 = _unitOfWork.dbContext.Employees.GroupJoin(
                _unitOfWork.dbContext.Department,
                emp => emp.departmentid,
                depar => depar.departmentid,
                (e, d) => new { employee = e, department = d })
                .SelectMany(x => x.department.DefaultIfEmpty(),
                (y, z) => new { y.employee, z })
                .GroupBy(g => new { g.employee.EmployeeName })
                .Where(j => j.Count() > 1)
                .Select( i => new ClsEmp
                {
                    EmpName = i.Key.EmployeeName,
                    deparcount = i.Count()
                } )
                .ToList();


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

        public int InsertuserData (ClsCurrentUserInterface request)
        {
            try
            {
                var userobj = new ClsUser
                {
                    email = request.email,
                    token = request.token,
                    username = request.username,
                    bio = request.bio,
                    image = request.image
                };
                _unitOfWork.dbContext.users.Add(userobj);
                _unitOfWork.dbContext.SaveChanges();

                return userobj.userId;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool Login(ClsLoginRequestInterface reques)
        {
            try
            {
                if(_unitOfWork.dbContext.users.Any(x=>x.email == reques.user.email))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw;
            }
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
