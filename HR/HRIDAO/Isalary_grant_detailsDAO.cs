using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIDAO
{
    public interface Isalary_grant_detailsDAO
    {
        int salary_grant_detailsAdd(salary_grant_detailsModel s);

        int salary_grant_detailsUpd(salary_grant_detailsModel s);

        int salary_grant_detailsDel(salary_grant_detailsModel s);

        List<salary_grant_detailsModel> salary_grant_detailsAll();
    }
}
