using HRIBLL;
using HRIDAO;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBLL
{
    public class config_file_second_kindBLL : Iconfig_file_second_kindBLL
    {
        public Iconfig_file_second_kindDAO ioc { get; set; }
        public List<config_file_second_kindModel> All()
        {
            return ioc.All();
        }

        public int FKAdd(config_file_second_kindModel csk)
        {
            return ioc.FKAdd(csk);
        }

        public int FKDelete(config_file_second_kindModel csk)
        {
            return ioc.FKDelete(csk);
        }

        public int FKUpdate(config_file_second_kindModel csk)
        {
            return ioc.FKUpdate(csk);
        }
    }
}
