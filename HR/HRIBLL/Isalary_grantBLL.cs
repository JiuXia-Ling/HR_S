using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Isalary_grantBLL
    {
        int salary_grantAdd(salary_grantModel s);

        int salary_grantDel(salary_grantModel s);

        int salary_grantUpd(salary_grantModel s);

        List<salary_grantModel> salary_grantAll();
        
        List<salary_grantModel> salary_grantFy(string sqlstr, int pageIndex, int pagesize, string orderByField, ref int totalCount, string where);
    }
}
