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
    public class salary_grantBLL: Isalary_grantBLL
    {
        public Isalary_grantDAO ioc { get; set; }

        public int salary_grantAdd(salary_grantModel s)
        {
            return ioc.salary_grantAdd(s);
        }

        public List<salary_grantModel> salary_grantAll()
        {
            return ioc.salary_grantAll();
        }

        public int salary_grantDel(salary_grantModel s)
        {
            return ioc.salary_grantDel(s);
        }

        public List<salary_grantModel> salary_grantFy(string sqlstr, int pageIndex, int pagesize, string orderByField, ref int totalCount, string where)
        {
            return ioc.salary_grantFy(sqlstr, pageIndex, pagesize, orderByField,ref totalCount,where);
        }

        public int salary_grantUpd(salary_grantModel s)
        {
            return ioc.salary_grantUpd(s);
        }
    }
}
