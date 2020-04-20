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
    public class salar_standard_itemDAO : BaseDao<salar_standard_item>, Isalar_standard_itemDAO
    {
        public List<salar_standard_itemModel> sstAll()
        {
            List<salar_standard_item> list1 = select();
            List<salar_standard_itemModel> list2 = new List<salar_standard_itemModel>();
            foreach (salar_standard_item item in list1)
            {
                salar_standard_itemModel ss = new salar_standard_itemModel()
                {
                    item_id=item.item_id,
                    Myitem_name=item.Myitem_name
                };
                list2.Add(ss);
            }
            return list2;
        }
    }
}
