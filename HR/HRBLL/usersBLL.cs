using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRModel;
using HREFProject;
using HRIBLL;
using HRIDAO;

namespace HRBLL
{
    public class usersBLL:IusersBLL
    {
        public IusersDAO ioc { get; set; }

        public List<usersModel> us()
        {
            return ioc.us();
        }
    }
}
