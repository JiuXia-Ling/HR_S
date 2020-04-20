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
    public class config_public_charDAO : BaseDao<config_public_char>, Iconfig_public_charDAO
    {
        public int cpcAdd(config_public_charModel cpc)
        {
            config_public_char cc = new config_public_char()
            {
                attribute_kind = cpc.attribute_kind,
                attribute_name = cpc.attribute_name,
                pbc_id = cpc.pbc_id
            };
            return Add(cc);
        }

        public List<config_public_charModel> cpcAll()
        {
            List<config_public_char> list1 = select();
            List<config_public_charModel> list2 = new List<config_public_charModel>();
            foreach (config_public_char item in list1)
            {
                config_public_charModel cc = new config_public_charModel()
                {
                    attribute_kind=item.attribute_kind,
                    attribute_name=item.attribute_name,
                    pbc_id=item.pbc_id
                };
                list2.Add(cc);
            }
            return list2;
        }

        public int cpcDelete(config_public_charModel cpc)
        {
            config_public_char cc = new config_public_char()
            {
                pbc_id = cpc.pbc_id
            };
            return Delete(cc);
        }
    }
}
