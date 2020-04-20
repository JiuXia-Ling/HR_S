using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIBLL;
using HRModel;
using HRIDAO;

namespace HRBLL
{
    public class config_file_first_kindBLL : Iconfig_file_first_kindBLL
    {
        public Iconfig_file_first_kindDAO ioc { get; set; }

        public int cffkAdd(config_file_first_kindModel cffk)
        {
            return ioc.cffkAdd(cffk);
        }

        public List<config_file_first_kindModel> cffkAll()
        {
            return ioc.cffkAll();
        }

        public int cffkDel(config_file_first_kindModel cffk)
        {
            return ioc.cffkDel(cffk);
        }

        public int cffkUpd(config_file_first_kindModel cffk)
        {
            return ioc.cffkUpd(cffk);
        }
    }
}
