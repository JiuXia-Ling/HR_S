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
    public class config_major_kindDAO : BaseDao<config_major_kind>, Iconfig_major_kindDAO
    {
        public int cmkAdd(config_major_kindModel cmk)
        {
            config_major_kind ck = new config_major_kind()
            {
                major_kind_id = cmk.major_kind_id,
                major_kind_name = cmk.major_kind_name,
                mfk_id = cmk.mfk_id,
            };
            return Add(ck);
        }

        public List<config_major_kindModel> cmkAll()
        {
            List<config_major_kind> list1 = select();
            List<config_major_kindModel> list2 = new List<config_major_kindModel>();
            foreach (config_major_kind item in list1)
            {
                config_major_kindModel ck = new config_major_kindModel()
                {
                    major_kind_id = item.major_kind_id,
                    major_kind_name = item.major_kind_name,
                    mfk_id = item.mfk_id,
                };
                list2.Add(ck);
            }
            return list2;
        }

        public int cmkDelete(config_major_kindModel cmk)
        {
            config_major_kind ck = new config_major_kind()
            {
                mfk_id = cmk.mfk_id,
            };
            return Delete(ck);
        }
    }
}
