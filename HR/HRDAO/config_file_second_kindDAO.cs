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
    public class config_file_second_kindDAO :BaseDao<config_file_second_kind>,Iconfig_file_second_kindDAO
    {
        public List<config_file_second_kindModel> All()
        {
            List<config_file_second_kind> list1 = select();
            List<config_file_second_kindModel> list2 = new List<config_file_second_kindModel>();
            foreach (config_file_second_kind item in list1)
            {
                config_file_second_kindModel cfsk = new config_file_second_kindModel()
                {
                    fsk_id=item.fsk_id,
                    first_kind_id=item.first_kind_id,
                    first_kind_name=item.first_kind_name,
                    second_kind_id=item.second_kind_id,
                    second_kind_name=item.second_kind_name,
                    second_salary_id=item.second_salary_id,
                    second_sale_id=item.second_sale_id
                };
                list2.Add(cfsk);
            }
            return list2;
        }

        public int FKAdd(config_file_second_kindModel csk)
        {
            config_file_second_kind cfsk = new config_file_second_kind()
            {
                fsk_id = csk.fsk_id,
                first_kind_id = csk.first_kind_id,
                first_kind_name = csk.first_kind_name,
                second_kind_id = csk.second_kind_id,
                second_kind_name = csk.second_kind_name,
                second_salary_id = csk.second_salary_id,
                second_sale_id = csk.second_sale_id
            };
            return Add(cfsk);
        }

        public int FKDelete(config_file_second_kindModel csk)
        {
            config_file_second_kind cfsk = new config_file_second_kind()
            {
                fsk_id = csk.fsk_id,
            };
            return Delete(cfsk);
        }

        public int FKUpdate(config_file_second_kindModel csk)
        {
            config_file_second_kind cfsk = new config_file_second_kind()
            {
                fsk_id = csk.fsk_id,
                first_kind_id = csk.first_kind_id,
                first_kind_name = csk.first_kind_name,
                second_kind_id = csk.second_kind_id,
                second_kind_name = csk.second_kind_name,
                second_salary_id = csk.second_salary_id,
                second_sale_id = csk.second_sale_id
            };
            return Upd(cfsk);
        }
    }
}
