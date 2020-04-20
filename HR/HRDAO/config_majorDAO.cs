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
    class config_majorDAO : BaseDao<config_major>, Iconfig_majorDAO
    {
        public int cmAdd(config_majorModel cm)
        {
            config_major c = new config_major()
            {
                mak_id = cm.mak_id,
                major_id = cm.major_id,
                major_kind_id = cm.major_kind_id,
                major_kind_name = cm.major_kind_name,
                major_name = cm.major_name,
                test_amount = cm.test_amount
            };
            return Add(c);
        }

        public List<config_majorModel> cmAll()
        {
            List<config_major> list1 = select();
            List<config_majorModel> list2 = new List<config_majorModel>();
            foreach (var item in list1)
            {
                config_majorModel c = new config_majorModel()
                {
                    mak_id = item.mak_id,
                    major_id = item.major_id,
                    major_kind_id = item.major_kind_id,
                    major_kind_name = item.major_kind_name,
                    major_name = item.major_name,
                    test_amount = item.test_amount
                };
                list2.Add(c);
            }
            return list2;
        }

        public int cmDelete(config_majorModel cm)
        {
            config_major c = new config_major()
            {
                mak_id = cm.mak_id,
            };
            return Delete(c);
        }
    }
}
