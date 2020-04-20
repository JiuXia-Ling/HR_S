using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRModel;

namespace HRIDAO
{
    public interface Ihuman_fileDAO
    {
        int hfAdd(human_fileModel hf);

        int hfDel(human_fileModel hf);

        int hfUpd(human_fileModel hf);

        List<human_fileModel> hfAll();
    }
}
