using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Ihuman_fileBLL
    {
        int hfAdd(human_fileModel hf);

        int hfDel(human_fileModel hf);

        int hfUpd(human_fileModel hf);

        List<human_fileModel> hfAll();
    }
}
