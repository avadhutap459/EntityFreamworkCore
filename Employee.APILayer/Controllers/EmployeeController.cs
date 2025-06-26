using Employee.ServiceLayer.Interface;
using Employee.ServiceLayer.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee.APILayer.Controllers
{
    [EnableCors("CorsApi")]
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

        [HttpPost("Register")]
        public IActionResult Register(ClsRegisterRequestInterface request)
        {
            try
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Email, request.user.email),
                        new Claim("username", request.user.username)
                    };

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("yourSecretKeyyourSecretKeyyourSecretKeyyourSecretKey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string _token = tokenHandler.WriteToken(token);

                ClsCurrentUserInterface req = new ClsCurrentUserInterface
                {
                    email = request.user.email,
                    password = request.user.password,
                    token = _token,
                    username = request.user.username,
                    bio = "",
                    image = ""
                };

                int userId = Emp.InsertuserData(req);
              //  request.user = _token;


                if (userId > 0)
                {
                    return Ok(req);
                }

                return BadRequest();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult login(ClsLoginRequestInterface request)
        {
            try
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Email, request.user.email)
                    };

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("yourSecretKeyyourSecretKeyyourSecretKeyyourSecretKey");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string _token = tokenHandler.WriteToken(token);

                if(Emp.Login(request))
                {
                    request.user.token = _token;
                    return Ok(new { request });

                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
             
    }
}
