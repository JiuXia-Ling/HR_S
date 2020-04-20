using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRModel;
using HRIDAO;
using HRIBLL;

namespace HRBLL
{
    public class salary_standardBLL: Isalary_standardBLL
    {
        public Isalary_standardDAO ioc { get; set; }

        public Dictionary<int, List<salary_standardModel>> Fy(int CountIndex, int pageSize)
        {
            return ioc.Fy(CountIndex, pageSize);
        }

        public Dictionary<int, List<salary_standardModel>> FyW(string id, string key, DateTime start, DateTime end, int CountIndex, int pageSize, int state)
        {
            return ioc.FyW(id, key,start,end, CountIndex, pageSize,state);
        }

        public int ssAdd(salary_standardModel ss)
        {
            return ioc.ssAdd(ss);
        }

        public List<salary_standardModel> ssAll()
        {
            return ioc.ssAll();
        }

        public int ssDel(salary_standardModel ss)
        {
            return ioc.ssDel(ss);
        }

        public int ssUpd(salary_standardModel ss)
        {
            return ioc.ssUpd(ss);
        }
    }
}
