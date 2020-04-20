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
    public class salary_grant_detailsBLL: Isalary_grant_detailsBLL
    {
        public Isalary_grant_detailsDAO ioc { get; set; }

        public int salary_grant_detailsAdd(salary_grant_detailsModel s)
        {
            return ioc.salary_grant_detailsAdd(s);
        }

        public List<salary_grant_detailsModel> salary_grant_detailsAll()
        {
            return ioc.salary_grant_detailsAll();
        }

        public int salary_grant_detailsDel(salary_grant_detailsModel s)
        {
            return ioc.salary_grant_detailsDel(s);
        }

        public int salary_grant_detailsUpd(salary_grant_detailsModel s)
        {
            return ioc.salary_grant_detailsUpd(s);
        }
    }
}
