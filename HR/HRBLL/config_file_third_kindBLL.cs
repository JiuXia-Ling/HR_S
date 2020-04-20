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
    class config_file_third_kindBLL: Iconfig_file_third_kindBLL
    {
        public Iconfig_file_third_kindDAO ioc { get; set; }

        public List<config_file_third_kindModel> All()
        {
            return ioc.All();
        }

        public int KSAdd(config_file_third_kindModel ctk)
        {
            return ioc.KSAdd(ctk);
        }

        public int SKDelete(config_file_third_kindModel ctk)
        {
            return ioc.SKDelete(ctk);
        }

        public int SKUpdate(config_file_third_kindModel ctk)
        {
            return ioc.SKUpdate(ctk);
        }
    }
}
