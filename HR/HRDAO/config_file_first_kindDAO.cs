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
    public class config_file_first_kindDAO : BaseDao<config_file_first_kind>, Iconfig_file_first_kindDAO
    {
        public int cffkAdd(config_file_first_kindModel cffk)
        {
            config_file_first_kind ck = new config_file_first_kind()
            {
                ffk_id = cffk.ffk_id,
                first_kind_id = cffk.first_kind_id,
                first_kind_name = cffk.first_kind_name,
                first_kind_salary_id = cffk.first_kind_salary_id,
                first_kind_sale_id = cffk.first_kind_sale_id
            };
            return Add(ck);
        }

        public List<config_file_first_kindModel> cffkAll()
        {
            List<config_file_first_kind> lsit1 = select();
            List<config_file_first_kindModel> list2 = new List<config_file_first_kindModel>();
            foreach (config_file_first_kind item in lsit1)
            {
                config_file_first_kindModel ck = new config_file_first_kindModel()
                {
                    ffk_id = item.ffk_id,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    first_kind_salary_id = item.first_kind_salary_id,
                    first_kind_sale_id = item.first_kind_sale_id
                };
                list2.Add(ck);
            }
            return list2;
        }

        public int cffkDel(config_file_first_kindModel cffk)
        {
            config_file_first_kind ck = new config_file_first_kind()
            {
                ffk_id = cffk.ffk_id
            };
            return Delete(ck);
        }

        public int cffkUpd(config_file_first_kindModel cffk)
        {
            config_file_first_kind ck = new config_file_first_kind()
            {
                ffk_id = cffk.ffk_id,
                first_kind_id = cffk.first_kind_id,
                first_kind_name = cffk.first_kind_name,
                first_kind_salary_id = cffk.first_kind_salary_id,
                first_kind_sale_id = cffk.first_kind_sale_id
            };
            return Upd(ck);
        }
    }
}
