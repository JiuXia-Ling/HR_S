using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Iconfig_majorDAO
    {
        List<config_majorModel> cmAll();

        int cmDelete(config_majorModel cm);

        int cmAdd(config_majorModel cm);
    }
}
