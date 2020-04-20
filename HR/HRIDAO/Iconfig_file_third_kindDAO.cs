using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Iconfig_file_third_kindDAO
    {
        List<config_file_third_kindModel> All();

        int SKDelete(config_file_third_kindModel ctk);

        int KSAdd(config_file_third_kindModel ctk);

        int SKUpdate(config_file_third_kindModel ctk);
    }
}
