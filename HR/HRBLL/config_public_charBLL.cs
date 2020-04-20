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
    public class config_public_charBLL : Iconfig_public_charBLL
    {
        public Iconfig_public_charDAO ioc { get; set; }

        public int cpcAdd(config_public_charModel cpc)
        {
            return ioc.cpcAdd(cpc);
        }

        public List<config_public_charModel> cpcAll()
        {
            return ioc.cpcAll();
        }

        public int cpcDelete(config_public_charModel cpc)
        {
            return ioc.cpcDelete(cpc);
        }
    }
}
