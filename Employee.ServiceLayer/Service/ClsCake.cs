using Employee.DBLayer.DBModel;
using Employee.ServiceLayer.EF.Interface;
using Employee.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Service
{
    public class ClsCake : ICake
    {
        public IUnitOfWork _unitOfWork;
        public ClsCake(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public async Task<List<Cake>> AllCakeAsync()
        {
            return await _unitOfWork.dbContext.cakes.ToListAsync();
        }
    }
}
