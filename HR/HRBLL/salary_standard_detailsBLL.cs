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
    public class salary_standard_detailsBLL : Isalary_standard_detailsBLL
    {
        public Isalary_standard_detailsDAO ioc { get; set; }

        public int ssdAdd(salary_standard_detailsModel ssd)
        {
            return ioc.ssdAdd(ssd);
        }

        public List<salary_standard_detailsModel> ssdAll()
        {
            return ioc.ssdAll();
        }

        public int ssdDel(salary_standard_detailsModel ssd)
        {
            return ioc.ssdDel(ssd);
        }

        public int ssdUpd(salary_standard_detailsModel ssd)
        {
            return ioc.ssdUpd(ssd);
        }
    }
}
