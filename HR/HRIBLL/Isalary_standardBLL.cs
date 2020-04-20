using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIBLL
{
    public interface Isalary_standardBLL
    {
        int ssAdd(salary_standardModel ss);

        int ssDel(salary_standardModel ss);

        int ssUpd(salary_standardModel ss);

        List<salary_standardModel> ssAll();

        Dictionary<int, List<salary_standardModel>> Fy(int CountIndex, int pageSize);

        Dictionary<int, List<salary_standardModel>> FyW(string id, string key, DateTime start, DateTime end, int CountIndex, int pageSize,int state);
    }
}
