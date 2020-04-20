using HREFProject;
using HRIDAO;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAO
{
    public class salary_grant_detailsDAO : BaseDao<salary_grant_details>, Isalary_grant_detailsDAO
    {
        public int salary_grant_detailsAdd(salary_grant_detailsModel s)
        {
            salary_grant_details sm = new salary_grant_details()
            {
                grd_id = s.grd_id,
                salary_grant_id = s.salary_grant_id,
                salary_paid_sum = s.salary_paid_sum,
                salary_standard_sum = s.salary_standard_sum,
                sale_sum = s.sale_sum,
                bouns_sum = s.bouns_sum,
                deduct_sum = s.deduct_sum,
                human_id = s.human_id,
                human_name = s.human_name,
                salary_standard_id = s.salary_standard_id
                
            };
            return Add(sm);
        }

        public List<salary_grant_detailsModel> salary_grant_detailsAll()
        {
            List<salary_grant_details> list = select();
            List<salary_grant_detailsModel> sg = new List<salary_grant_detailsModel>();
            foreach (salary_grant_details item in list)
            {
                salary_grant_detailsModel sm = new salary_grant_detailsModel()
                {
                    grd_id = item.grd_id,
                    salary_grant_id=item.salary_grant_id,
                    salary_paid_sum=item.salary_paid_sum,
                    salary_standard_sum=item.salary_standard_sum,
                    sale_sum=item.sale_sum,
                    bouns_sum=item.bouns_sum,
                    deduct_sum=item.deduct_sum,
                    human_id=item.human_id,
                    human_name=item.human_name,
                    salary_standard_id = item.salary_standard_id
                };
                sg.Add(sm);
            }
            return sg;
        }

        public int salary_grant_detailsDel(salary_grant_detailsModel s)
        {
            salary_grant_details sm = new salary_grant_details()
            {
                grd_id = s.grd_id
            };
            return Delete(sm);
        }

        public int salary_grant_detailsUpd(salary_grant_detailsModel s)
        {
            salary_grant_details sm = new salary_grant_details()
            {
                grd_id = s.grd_id,
                salary_grant_id = s.salary_grant_id,
                salary_paid_sum = s.salary_paid_sum,
                salary_standard_sum = s.salary_standard_sum,
                sale_sum = s.sale_sum,
                bouns_sum = s.bouns_sum,
                deduct_sum = s.deduct_sum,
                human_id = s.human_id,
                human_name = s.human_name,
                salary_standard_id = s.salary_standard_id
            };
            return Upd(sm);
        }
    }
}
