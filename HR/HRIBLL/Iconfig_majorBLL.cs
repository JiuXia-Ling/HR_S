using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Iconfig_majorBLL
    {
        List<config_majorModel> cmAll();

        int cmDelete(config_majorModel cm);

        int cmAdd(config_majorModel cm);
    }
}
