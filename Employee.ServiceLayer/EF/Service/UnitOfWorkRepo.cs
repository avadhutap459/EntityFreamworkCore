using Employee.DBLayer;
using Employee.ServiceLayer.EF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.EF.Service
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly EmployeeDbContext _dbcontext;
        public UnitOfWorkRepo(EmployeeDbContext dbContext) 
        { 
            _dbcontext = dbContext;
        }

        public EmployeeDbContext dbContext
        {
            get { return _dbcontext; }
        }


        public
            void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if(disposing)
            {
                _dbcontext.Dispose();
            }
        }
    }
}
