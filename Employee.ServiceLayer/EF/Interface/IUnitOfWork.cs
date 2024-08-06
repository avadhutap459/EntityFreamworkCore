using Employee.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.EF.Interface
{
    public interface IUnitOfWork
    {
        EmployeeDbContext dbContext { get; }
    }
}
