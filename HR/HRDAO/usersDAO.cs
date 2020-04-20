using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HREFProject;
using HRIDAO;
using HRModel;

namespace HRDAO
{
    public class usersDAO : BaseDao<users>, IusersDAO
    {

        public List<usersModel> us()
        {
            List<users> list1 = select();
            List<usersModel> list2 = new List<usersModel>();
            foreach (users item in list1)
            {
                usersModel usm = new usersModel()
                {
                    u_id = item.u_id,
                    u_name=item.u_name,
                    u_password=item.u_password,
                    u_true_name=item.u_true_name
                };
                list2.Add(usm);
            }
            return list2;
        }
    }
}
