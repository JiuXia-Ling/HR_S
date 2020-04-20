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
    public class config_major_kindBLL : Iconfig_major_kindBLL
    {
        public Iconfig_major_kindDAO ioc { get; set; }

        public int cmkAdd(config_major_kindModel cmk)
        {
            return ioc.cmkAdd(cmk);
        }

        public List<config_major_kindModel> cmkAll()
        {
            return ioc.cmkAll();
        }

        public int cmkDelete(config_major_kindModel cmk)
        {
            return ioc.cmkDelete(cmk);
        }
    }
}
