using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Iconfig_major_kindDAO
    {
        List<config_major_kindModel> cmkAll();

        int cmkAdd(config_major_kindModel cmk);

        int cmkDelete(config_major_kindModel cmk);
    }
}
