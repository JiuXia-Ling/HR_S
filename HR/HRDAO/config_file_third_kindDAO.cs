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
    class config_file_third_kindDAO : BaseDao<config_file_third_kind>,Iconfig_file_third_kindDAO
    {
        public List<config_file_third_kindModel> All()
        {
            List<config_file_third_kind> list1 = select();
            List<config_file_third_kindModel> list2 = new List<config_file_third_kindModel>();
            foreach (config_file_third_kind item in list1)
            {
                config_file_third_kindModel ctf = new config_file_third_kindModel()
                {
                    ftk_id=item.ftk_id,
                    first_kind_id=item.first_kind_id,
                    first_kind_name=item.first_kind_name,
                    second_kind_id=item.second_kind_id,
                    second_kind_name=item.second_kind_name,
                    third_kind_id=item.third_kind_id,
                    third_kind_is_retail=item.third_kind_is_retail,
                    third_kind_name=item.third_kind_name,
                    third_kind_sale_id=item.third_kind_sale_id
                };
                list2.Add(ctf);
            };
            return list2;
        }

        public int KSAdd(config_file_third_kindModel ctk)
        {
            config_file_third_kind ctf = new config_file_third_kind()
            {
                ftk_id = ctk.ftk_id,
                first_kind_id = ctk.first_kind_id,
                first_kind_name = ctk.first_kind_name,
                second_kind_id = ctk.second_kind_id,
                second_kind_name = ctk.second_kind_name,
                third_kind_id = ctk.third_kind_id,
                third_kind_is_retail = ctk.third_kind_is_retail,
                third_kind_name = ctk.third_kind_name,
                third_kind_sale_id = ctk.third_kind_sale_id
            };
            return Add(ctf);
        }

        public int SKDelete(config_file_third_kindModel ctk)
        {
            config_file_third_kind ctf = new config_file_third_kind()
            {
                ftk_id = ctk.ftk_id
            };
            return Delete(ctf);
        }

        public int SKUpdate(config_file_third_kindModel ctk)
        {
            config_file_third_kind ctf = new config_file_third_kind()
            {
                ftk_id = ctk.ftk_id,
                first_kind_id = ctk.first_kind_id,
                first_kind_name = ctk.first_kind_name,
                second_kind_id = ctk.second_kind_id,
                second_kind_name = ctk.second_kind_name,
                third_kind_id = ctk.third_kind_id,
                third_kind_is_retail = ctk.third_kind_is_retail,
                third_kind_name = ctk.third_kind_name,
                third_kind_sale_id = ctk.third_kind_sale_id
            };
            return Upd(ctf);
        }
    }
}
