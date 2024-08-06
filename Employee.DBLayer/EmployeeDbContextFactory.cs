using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBLayer
{
    public class EmployeeDbContextFactory : IDesignTimeDbContextFactory<EmployeeDbContext>
    {
        public static string appDirectory = System.Environment.CurrentDirectory;
        public static string env = string.Empty;
        public EmployeeDbContext CreateDbContext(string[] args)
        {
            string Path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf('\\')) + '\\' + "Employee.APILayer";

            var config = new ConfigurationBuilder().SetBasePath(Path).AddJsonFile("appsettings.json").Build();

            env = config.GetSection("Env").Value;

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path).AddJsonFile($"appsettings.{env}.json").Build();

            var dbcontextOptionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>();

            dbcontextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new EmployeeDbContext(dbcontextOptionsBuilder.Options);
        }
    }
}
