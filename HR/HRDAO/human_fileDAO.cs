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
    public class human_fileDAO : BaseDao<human_file>, Ihuman_fileDAO
    {
        public int hfAdd(human_fileModel hf)
        {
            human_file h = new human_file()
            {
                huf_id = hf.huf_id,
                human_id = hf.human_id,
                demand_salaray_sum = hf.demand_salaray_sum,
                human_name = hf.human_name,
                first_kind_id = hf.first_kind_id,
                first_kind_name = hf.first_kind_name,
                paid_salary_sum = hf.paid_salary_sum,
                salary_standard_id = hf.salary_standard_id,
                salary_standard_name = hf.salary_standard_name,
                salary_sum = hf.salary_sum,
                second_kind_id = hf.second_kind_id,
                second_kind_name = hf.second_kind_name,
                third_kind_id = hf.third_kind_id,
                third_kind_name = hf.third_kind_name
            };
            return Add(h);
        }

        public List<human_fileModel> hfAll()
        {
            List<human_file> list1 = select();
            List<human_fileModel> list2 = new List<human_fileModel>();
            foreach (human_file item in list1)
            {
                human_fileModel hf = new human_fileModel()
                {
                    huf_id=item.huf_id,
                    human_id=item.human_id,
                    demand_salaray_sum=item.demand_salaray_sum,
                    human_name=item.human_name,
                    first_kind_id=item.first_kind_id,
                    first_kind_name=item.first_kind_name,
                    paid_salary_sum=item.paid_salary_sum,
                    salary_standard_id=item.salary_standard_id,
                    salary_standard_name=item.salary_standard_name,
                    salary_sum=item.salary_sum,
                    second_kind_id=item.second_kind_id,
                    second_kind_name=item.second_kind_name,
                    third_kind_id=item.third_kind_id,
                    third_kind_name=item.third_kind_name,
                    check_status=item.check_status
                    
                };
                list2.Add(hf);
            }
            return list2;
        }

        public int hfDel(human_fileModel hf)
        {
            human_file h = new human_file()
            {
                huf_id = hf.huf_id
            };
            return Delete(h);
        }

        public int hfUpd(human_fileModel hf)
        {
            human_file h = new human_file()
            {
                huf_id = hf.huf_id,
                human_id = hf.human_id,
                demand_salaray_sum = hf.demand_salaray_sum,
                human_name = hf.human_name,
                first_kind_id = hf.first_kind_id,
                first_kind_name = hf.first_kind_name,
                paid_salary_sum = hf.paid_salary_sum,
                salary_standard_id = hf.salary_standard_id,
                salary_standard_name = hf.salary_standard_name,
                salary_sum = hf.salary_sum,
                second_kind_id = hf.second_kind_id,
                second_kind_name = hf.second_kind_name,
                third_kind_id = hf.third_kind_id,
                third_kind_name = hf.third_kind_name
            };
            return Upd(h);
        }
    }
}
