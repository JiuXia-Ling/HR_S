using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Iconfig_file_second_kindDAO
    {
        List<config_file_second_kindModel> All();

        int FKAdd(config_file_second_kindModel csk);

        int FKDelete(config_file_second_kindModel csk);

        int FKUpdate(config_file_second_kindModel csk);
    }
}
