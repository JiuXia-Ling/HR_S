using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRModel;
using HRIDAO;
using HREFProject;

namespace HRDAO
{
    class salary_standardDAO :BaseDao<salary_standard>, Isalary_standardDAO
    {
        public Dictionary<int, List<salary_standardModel>> Fy(int CountIndex, int pageSize)
        {
            var data = select().OrderBy(e => e.ssd_id).Where(e=>e.check_status != 2);
            var rows = data.Count();
            var result = data.Skip((CountIndex - 1) * pageSize).Take(pageSize);
            List<salary_standardModel> ss = new List<salary_standardModel>();
            foreach (var item in result)
            {
                salary_standardModel s = new salary_standardModel()
                {
                    changer = item.changer,
                    change_status = item.change_status,
                    salary_sum = item.salary_sum,
                    ssd_id = item.ssd_id,
                    standard_id = item.standard_id,
                    standard_name = item.standard_name,
                    check_status = item.check_status,
                    change_time = item.change_time,
                    checker = item.checker,
                    check_comment = item.check_comment,
                    check_time = item.check_time,
                    designer = item.designer,
                    register = item.register,
                    regist_time = item.regist_time,
                    remark = item.remark
                };
                ss.Add(s);
            }
            Dictionary<int, List<salary_standardModel>> dic = new Dictionary<int, List<salary_standardModel>>();
            dic.Add(rows, ss);
            return dic;
        }

        public Dictionary<int, List<salary_standardModel>> FyW(string id, string key, DateTime start, DateTime end, int CountIndex, int pageSize,int state)
        {
            var data = select().OrderBy(e => e.ssd_id).Where(e =>1==1);
            if (key == "")
            {
                data = select().OrderBy(e => e.ssd_id).Where(e => e.standard_id.Contains(id) && e.regist_time > start && e.regist_time < end);
            }
            else
            {
                data = null;
                data= select().OrderBy(e => e.ssd_id).Where(e => e.standard_id.Contains(id) && e.regist_time > start && e.regist_time < end &&e.standard_name.Contains(key));//薪酬标准单名称
                if (data.Count() == 0)
                {
                    data = select().OrderBy(e => e.ssd_id).Where(e => e.standard_id.Contains(id) && e.regist_time > start && e.regist_time < end && e.register.Contains(key));//登记人
                    if (data.Count() == 0)
                    {
                        data = select().OrderBy(e => e.ssd_id).Where(e => e.standard_id.Contains(id) && e.regist_time > start && e.regist_time < end && e.checker.Contains(key));//复核人
                        if (data.Count() == 0)
                        {
                            data = select().OrderBy(e => e.ssd_id).Where(e => e.standard_id.Contains(id) && e.regist_time > start && e.regist_time < end && e.changer.Contains(key));//变更人
                        }
                    }
                }
            }
            if (state == 0)
            {
                data = data.Where(e => e.check_status != 2).ToList();
            }
            else
            {
                data = data.Where(e => e.check_status == 2).ToList();
            }
            int rows = data.Count();
            var result = data.Skip((CountIndex - 1) * pageSize).Take(pageSize);
            List<salary_standardModel> ss = new List<salary_standardModel>();
            foreach (var item in result)
            {
                salary_standardModel s = new salary_standardModel()
                {
                    changer = item.changer,
                    change_status = item.change_status,
                    salary_sum = item.salary_sum,
                    ssd_id = item.ssd_id,
                    standard_id = item.standard_id,
                    standard_name = item.standard_name,
                    check_status = item.check_status,
                    change_time = item.change_time,
                    checker = item.checker,
                    check_comment = item.check_comment,
                    check_time = item.check_time,
                    designer = item.designer,
                    register = item.register,
                    regist_time = item.regist_time,
                    remark = item.remark
                };
                ss.Add(s);
            }
            Dictionary<int, List<salary_standardModel>> dic = new Dictionary<int, List<salary_standardModel>>();
            dic.Add(rows, ss);
            return dic;
        }

        public int ssAdd(salary_standardModel ss)
        {
            salary_standard s = new salary_standard()
            {
                changer = ss.changer,
                change_status = ss.change_status,
                salary_sum = ss.salary_sum,
                standard_id = ss.standard_id,
                standard_name = ss.standard_name,
                check_status = ss.check_status,
                change_time = ss.change_time,
                checker = ss.checker,
                check_comment = ss.check_comment,
                check_time = ss.check_time,
                designer = ss.designer,
                register = ss.register,
                regist_time = ss.regist_time,
                remark = ss.remark,
            };
            return Add(s);
        }

        public List<salary_standardModel> ssAll()
        {
            List<salary_standard> list1 = select();
            List<salary_standardModel> list2 = new List<salary_standardModel>();
            foreach (salary_standard item in list1)
            {
                salary_standardModel ss = new salary_standardModel()
                {
                    changer = item.changer,
                    change_status=item.change_status,
                    salary_sum=item.salary_sum,
                    ssd_id=item.ssd_id,
                    standard_id=item.standard_id,
                    standard_name=item.standard_name,
                    check_status=item.check_status,
                    change_time=item.change_time,
                    checker=item.checker,
                    check_comment=item.check_comment,
                    check_time=item.check_time,
                    designer=item.designer,
                    register=item.register,
                    regist_time=item.regist_time,
                    remark=item.remark
                };
                list2.Add(ss);
            }
            return list2;
        }

        public int ssDel(salary_standardModel ss)
        {
            salary_standard s = new salary_standard()
            {
                ssd_id = ss.ssd_id
            };
            return Delete(s);
        }

        public int ssUpd(salary_standardModel ss)
        {
            salary_standard s = new salary_standard()
            {
                changer = ss.changer,
                change_status = ss.change_status,
                salary_sum = ss.salary_sum,
                standard_id = ss.standard_id,
                standard_name = ss.standard_name,
                check_status = ss.check_status,
                change_time = ss.change_time,
                checker = ss.checker,
                check_comment = ss.check_comment,
                check_time = ss.check_time,
                designer = ss.designer,
                register = ss.register,
                regist_time = ss.regist_time,
                remark = ss.remark,
                ssd_id = ss.ssd_id
            };
            return Upd(s);
        }
    }
}
