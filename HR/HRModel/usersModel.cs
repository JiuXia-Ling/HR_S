using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class usersModel
    {
        public int u_id { get; set; }

        [Required(ErrorMessage = "请输入登录用户名")]
        public string u_name { get; set; }

        public string u_true_name { get; set; }

        [Required(ErrorMessage = "请输入登录密码")]
        public string u_password { get; set; }
    }
}
