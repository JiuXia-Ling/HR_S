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
    public class human_fileBLL: Ihuman_fileBLL
    {
        public Ihuman_fileDAO ioc { get; set; }

        public int hfAdd(human_fileModel hf)
        {
            return ioc.hfAdd(hf);
        }

        public List<human_fileModel> hfAll()
        {
            return ioc.hfAll();
        }

        public int hfDel(human_fileModel hf)
        {
            return ioc.hfDel(hf);
        }

        public int hfUpd(human_fileModel hf)
        {
            return ioc.hfUpd(hf);
        }
    }
}
