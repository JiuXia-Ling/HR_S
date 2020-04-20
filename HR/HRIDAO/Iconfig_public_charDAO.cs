using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Iconfig_public_charDAO
    {
        List<config_public_charModel> cpcAll();

        int cpcAdd(config_public_charModel cpc);

        int cpcDelete(config_public_charModel cpc);
    }
}
