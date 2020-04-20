using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRModel;

namespace HRIDAO
{
    public interface Isalary_grantDAO
    {
        int salary_grantAdd(salary_grantModel s);

        int salary_grantDel(salary_grantModel s);

        int salary_grantUpd(salary_grantModel s);

        List<salary_grantModel> salary_grantAll();

        List<salary_grantModel> salary_grantFy(string sqlstr, int pageIndex, int pagesize, string orderByField, ref int totalCount, string where);
    }
}
