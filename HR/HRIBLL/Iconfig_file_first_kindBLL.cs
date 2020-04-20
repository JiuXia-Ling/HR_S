using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Iconfig_file_first_kindBLL
    {
        int cffkAdd(config_file_first_kindModel cffk);

        int cffkUpd(config_file_first_kindModel cffk);

        int cffkDel(config_file_first_kindModel cffk);

        List<config_file_first_kindModel> cffkAll();
    }
}
