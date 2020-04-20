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
    public class config_majorBLL : Iconfig_majorBLL
    {
        public Iconfig_majorDAO ioc { get; set; }

        public int cmAdd(config_majorModel cm)
        {
            return ioc.cmAdd(cm);
        }

        public List<config_majorModel> cmAll()
        {
            return ioc.cmAll();
        }

        public int cmDelete(config_majorModel cm)
        {
            return ioc.cmDelete(cm);
        }
    }
}
