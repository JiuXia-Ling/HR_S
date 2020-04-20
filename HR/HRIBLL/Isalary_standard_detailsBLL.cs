
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Isalary_standard_detailsBLL
    {
        int ssdAdd(salary_standard_detailsModel ssd);

        int ssdUpd(salary_standard_detailsModel ssd);

        int ssdDel(salary_standard_detailsModel ssd);

        List<salary_standard_detailsModel> ssdAll();
    }
}
