using HREFProject;
using HRIDAO;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAO
{
    public class salary_grantDAO : BaseDao<salary_grant>, Isalary_grantDAO
    {
        public int salary_grantAdd(salary_grantModel s)
        {
            salary_grant sg = new salary_grant()
            {
                sgr_id = s.sgr_id,
                checker = s.checker,
                check_status = s.check_status,
                check_time = s.check_time,
                first_kind_id = s.first_kind_id,
                first_kind_name = s.first_kind_name,
                human_amount = s.human_amount,
                register = s.register,
                regist_time = s.regist_time,
                salary_grant_id = s.salary_grant_id,
                salary_paid_sum = s.salary_paid_sum,
                salary_standard_sum = s.salary_standard_sum,
                second_kind_id = s.second_kind_id,
                second_kind_name = s.second_kind_name,
                third_kind_id = s.third_kind_id,
                third_kind_name = s.third_kind_name
            };
            return Add(sg);
        }

        public List<salary_grantModel> salary_grantAll()
        {
            List<salary_grant> list = select();
            List<salary_grantModel> sm = new List<salary_grantModel>();
            foreach (salary_grant item in list)
            {
                salary_grantModel sg = new salary_grantModel()
                {
                    sgr_id = item.sgr_id,
                    checker =item.checker,
                    check_status=item.check_status,
                    check_time=item.check_time,
                    first_kind_id=item.first_kind_id,
                    first_kind_name=item.first_kind_name,
                    human_amount=item.human_amount,
                    register=item.register,
                    regist_time=item.regist_time,
                    salary_grant_id=item.salary_grant_id,
                    salary_paid_sum=item.salary_paid_sum,
                    salary_standard_sum=item.salary_standard_sum,
                    second_kind_id=item.second_kind_id,
                    second_kind_name=item.second_kind_name,
                    third_kind_id=item.third_kind_id,
                    third_kind_name=item.third_kind_name
                };
                sm.Add(sg);
            }
            return sm;
        }

        public int salary_grantDel(salary_grantModel s)
        {
            salary_grant sg = new salary_grant()
            {
                sgr_id = s.sgr_id
            };
            return Delete(sg);
        }

        public List<salary_grantModel> salary_grantFy(string sqlstr, int pageIndex, int pagesize, string orderByField, ref int totalCount,string where )
        {
            string strSql = $"select * from salary_grant where {where}";
            string orderfied = "order by sgr_id desc";
            return SelectPageList<salary_grantModel>(strSql, pageIndex, pagesize, orderfied, ref totalCount);
        }

        public int salary_grantUpd(salary_grantModel s)
        {
            salary_grant sg = new salary_grant()
            {
                sgr_id = s.sgr_id,
                checker = s.checker,
                check_status = s.check_status,
                check_time = s.check_time,
                first_kind_id = s.first_kind_id,
                first_kind_name = s.first_kind_name,
                human_amount = s.human_amount,
                register = s.register,
                regist_time = s.regist_time,
                salary_grant_id = s.salary_grant_id,
                salary_paid_sum = s.salary_paid_sum,
                salary_standard_sum = s.salary_standard_sum,
                second_kind_id = s.second_kind_id,
                second_kind_name = s.second_kind_name,
                third_kind_id = s.third_kind_id,
                third_kind_name = s.third_kind_name
            };
            return Upd(sg);
        }
    }
}
