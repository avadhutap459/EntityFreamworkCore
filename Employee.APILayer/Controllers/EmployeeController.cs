using Employee.ServiceLayer.Interface;
using Employee.ServiceLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.APILayer.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployee Emp { get; set; }
        public EmployeeController(IEmployee _Emp)
        {
            Emp=_Emp;
        }
        [HttpGet("GetEmployeeCountBaseOnDepar")]
        public IActionResult GetEmployeeCountBaseOnDepar()
        {
            try
            {
                List<ClsEmp> emps = Emp.GetEmpCountBaseOnDepartment();

                return Ok(new { employee = emps });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEmployeeCountBaseOnDeparBySP")]
        public IActionResult GetEmployeeCountBaseOnDeparBySP()
        {
            try
            {
                List<ClsEmp> emps = Emp.GetEmpCountBaseOnDepartmentUsingSP();

                return Ok(new { employee = emps });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEmployeeByDepartId/{DeparId}")]
        public IActionResult GetEmployeeByDepartId(int DeparId)
        {
            try
            {
                List<ClsBMEmployee> emps = Emp.GetEmpDetailBaseOnDeparId(DeparId);

                return Ok(new { employee = emps });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
