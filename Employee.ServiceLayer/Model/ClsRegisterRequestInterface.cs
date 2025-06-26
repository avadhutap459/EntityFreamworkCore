using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.ServiceLayer.Model
{
    public class ClsRegisterRequestInterface
    {
        public ClsRegister user {  get; set; }
    }

    public class ClsRegister
    {
        [Required(ErrorMessage = "Email id is require")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is require")]
        public string password { get; set; }

        [Required(ErrorMessage = "Username is require")]
        public string username { get; set; }
    }

    public class ClsLoginRequestInterface
    {
        public ClsCurrentUserInterface user { get; set; }
    }
    public class ClsAuthResponseInterface
    {
        public ClsCurrentUserInterface user { get; set; }
    }
    public class ClsCurrentUserInterface
    {
        public string email { get; set; }

        public string password { get; set; }


        public string token { get; set; } = "";

        public string username { get; set; }
        public string bio { get; set; } = "";
        public string image { get; set; } = "";
    }
}
