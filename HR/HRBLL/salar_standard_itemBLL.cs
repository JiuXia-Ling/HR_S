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
    public class salar_standard_itemBLL: Isalar_standard_itemBLL
    {
        public Isalar_standard_itemDAO ioc { get; set; }

        public List<salar_standard_itemModel> sstAll()
        {
            return ioc.sstAll();
        }
    }
}
