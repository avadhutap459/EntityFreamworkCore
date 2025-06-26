using Employee.DBLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Interface
{
    public interface ICake
    {
        Task<List<Cake>> AllCakeAsync();
    }
}
