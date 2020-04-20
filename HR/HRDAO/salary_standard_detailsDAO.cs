using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HREFProject;
using HRIDAO;
using HRModel;

namespace HRDAO
{
    public class salary_standard_detailsDAO :BaseDao<salary_standard_details>, Isalary_standard_detailsDAO
    {
        public int ssdAdd(salary_standard_detailsModel ssd)
        {
            salary_standard_details ss = new salary_standard_details()
            {
                item_id = ssd.item_id,
                item_name = ssd.item_name,
                salary = ssd.salary,
                standard_id = ssd.standard_id,
                standard_name = ssd.standard_name
            };
            return Add(ss);
        }

        public List<salary_standard_detailsModel> ssdAll()
        {
            List<salary_standard_details> list1 = select();
            List<salary_standard_detailsModel> list2 = new List<salary_standard_detailsModel>();
            foreach (salary_standard_details item in list1)
            {
                salary_standard_detailsModel ss = new salary_standard_detailsModel()
                {
                    item_id=item.item_id,
                    item_name=item.item_name,
                    salary=item.salary,
                    sdt_id=item.sdt_id,
                    standard_id=item.standard_id,
                    standard_name=item.standard_name
                };
                list2.Add(ss);
            }
            return list2;
        }

        public int ssdDel(salary_standard_detailsModel ssd)
        {
            salary_standard_details ss = new salary_standard_details()
            {
                sdt_id = ssd.sdt_id,
            };
            return Delete(ss);
        }

        public int ssdUpd(salary_standard_detailsModel ssd)
        {
            salary_standard_details ss = new salary_standard_details()
            {
                item_id = ssd.item_id,
                item_name = ssd.item_name,
                salary = ssd.salary,
                standard_id = ssd.standard_id,
                standard_name = ssd.standard_name,
                sdt_id=ssd.sdt_id,
            };
            return Upd(ss);
        }
    }
}
