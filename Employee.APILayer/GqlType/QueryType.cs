using Employee.DBLayer;
using Employee.DBLayer.DBModel;
using Employee.ServiceLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace Employee.APILayer.GqlType
{
    public class QueryType
    {
        public async Task<List<Cake>> AllCakeAsync([Service] EmployeeDbContext dbContext)
        {
            return await dbContext.cakes.ToListAsync();
        }
    }
}
