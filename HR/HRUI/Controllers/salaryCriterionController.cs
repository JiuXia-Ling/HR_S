using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRIBLL;
using System.Web.Mvc;
using HRModel;
using Newtonsoft.Json;

namespace HRUI.Controllers
{
    public class salaryCriterionController : Controller
    {
        // GET: salaryCriterion
        public Isalar_standard_itemBLL sst { get; set; }
        public Isalary_standardBLL ss { get; set; }
        public Isalary_standard_detailsBLL issd { get; set; }
        #region 薪酬标准登记
        #region 薪酬标准登记添加页面显示
        [HttpGet]
        public ActionResult salarystandard_register()
        {
            ViewBag.Name = Session["Name"];
            salary_standardModel model = new salary_standardModel();//对应的实体类
            model.list = sst.sstAll();//给list集合赋值
            string id  = ss.ssAll().Max(e=>e.standard_id);
            int num = Convert.ToInt32(id.Substring(10))+1;
            if (num < 10)
            {
                id = "0" + num;
            }
            else
            {
                id = num.ToString() ;
            }
            string standard_id = "BH" + DateTime.Now.ToString("yyyyMMdd") + id;
            ViewBag.standard_id = standard_id;
            ViewBag.Count = model.list.Count;
            return View(model);
        }
        #endregion
        #region 薪酬标准登记添加
        [HttpPost]
        public ActionResult salarystandard_register(salary_standardModel ssm)
        {
            if (ModelState.IsValid)
            {
                salary_standardModel model = NewMethod1();
                int AK = 0;
                ssm.check_status = 0;
                if (ss.ssAdd(ssm) > 0)
                {
                    foreach (var item in ssm.lists)
                    {
                        salary_standard_detailsModel sd = new salary_standard_detailsModel()
                        {
                            standard_id = ssm.standard_id,
                            standard_name = ssm.standard_name,
                            salary = item.salary,
                            item_id = item.item_id,
                            item_name = item.item_name
                        };
                        if (issd.ssdAdd(sd) > 0)
                        {
                            AK++;
                        }
                    }
                    if (AK == ssm.lists.Count)
                    {
                        return Content("<script>alert('薪酬标准登记成功');window.location.href='/salaryCriterion/salarystandard_query_list'</script>");
                    }
                    else
                    {
                        ViewBag.ListCount = ssm.lists.Count();
                        ViewData.Model = model;
                        return Content("<script>alert('薪酬标准登记失败');window.location.href='/salaryCriterion/salarystandard_register'</script>");
                    }
                }
                else
                {
                    ViewBag.ListCount = ssm.lists.Count();
                    ViewData.Model = model;
                    return Content("<script>alert('薪酬标准登记失败');window.location.href='/salaryCriterion/salarystandard_register'</script>");
                }
            }
            else
            {
                salary_standardModel model = NewMethod1();
                ViewBag.ListCount = ssm.lists.Count();
                return View(model);
            }
        }
        private salary_standardModel NewMethod1()
        {
            ViewBag.Name = Session["Name"];
            salary_standardModel model = new salary_standardModel();//对应的实体类
            model.list = sst.sstAll();//给list集合赋值
            string id = ss.ssAll().Max(e => e.standard_id);
            int num = Convert.ToInt32(id.Substring(10)) + 1;
            if (num < 10)
            {
                id = "0" + num;
            }
            else
            {
                id = num.ToString();
            }
            string standard_id = "BH" + DateTime.Now.ToString("yyyyMMdd") + id;
            ViewBag.standard_id = standard_id;
            ViewBag.Count = model.list.Count;
            return model;
        }
        #endregion
        #region 薪酬标准登记查询页面
        [HttpGet]
        public ActionResult salarystandard_query_list()
        {
            return View();
        }
        #endregion
        #region 薪酬标准登记查询页面数据
        public ActionResult SelectCC(int CountIndex, int pageSize)
        {
            Dictionary<int, List<salary_standardModel>> dic1 = ss.Fy(CountIndex, pageSize);
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            foreach (KeyValuePair<int, List<salary_standardModel>> item in dic1)
            {
                dic2["dt"] = item.Value;
                dic2["rows"] = item.Key;
                dic2["pages"] = item.Key % pageSize == 0 ? item.Key / pageSize : (item.Key / pageSize) + 1;
            }
            string date = JsonConvert.SerializeObject(dic2);
            return Content(date);
        }
        #endregion
        #region 薪酬标准登记复核
        [HttpGet]
        public ActionResult salarystandard_check(int id)
        {
            string name = Session["Name"].ToString();
            List<salary_standardModel> list = ss.ssAll().Where(e => e.ssd_id == id).ToList();
            salary_standardModel s = new salary_standardModel();
            foreach (var item in list)
            {
                s.changer = item.changer;
                s.change_status = item.change_status;
                s.salary_sum = item.salary_sum;
                s.ssd_id = item.ssd_id;
                s.standard_id = item.standard_id;
                s.standard_name = item.standard_name;
                s.check_status = item.check_status;
                s.change_time = item.change_time;
                s.checker = name;
                s.check_comment = item.check_comment;
                s.check_time = item.check_time;
                s.designer = item.designer;
                s.register = item.register;
                s.regist_time = item.regist_time;
                s.remark = item.remark;
                s.lists = issd.ssdAll().Where(e => e.standard_id == item.standard_id).ToList();
            }
            ViewData.Model = s;
            return View();
        }
        #endregion
        #region 薪酬标准登记复核实施
        [HttpPost]
        public ActionResult salarystandard_check(salary_standardModel ssm)
        {
            ViewBag.Name = Session["Name"];
            int AK = 0;
            if (ModelState.IsValid)
            {
                ssm.check_status = 2;
                if (ss.ssUpd(ssm) > 0)
                {
                    foreach (var item in ssm.lists)
                    {
                        salary_standard_detailsModel sd = new salary_standard_detailsModel()
                        {
                            standard_id = item.standard_id,
                            standard_name = ssm.standard_name,
                            salary = item.salary,
                            item_id = item.item_id,
                            item_name = item.item_name,
                            sdt_id = item.sdt_id
                        };
                        if (issd.ssdUpd(sd) > 0)
                        {
                            AK++;
                        }
                    }
                }
                if (AK == ssm.lists.Count)
                {
                    return Content("<script>alert('薪酬标准登记复核成功');window.location.href='/salaryCriterion/salarystandard_query_list'</script>");
                }
                else
                {
                    NewMethod(ssm.ssd_id);
                    return Content("<script>alert('薪酬标准登记复核失败');window.location.href='/salaryCriterion/salarystandard_check'</script>");
                }
            }
            else
            {
                return View(ssm);
            }

        }
        #endregion
        #region 薪酬标准查询页面
        [HttpGet]
        public ActionResult salarystandard_change_locate()
        {
            return View();
        }
        #endregion
        #region 薪酬标准查询
        [HttpPost]
        public ActionResult salarystandard_change_locate(salary_standardModel s)
        {
            
            Session["id"] = s.standard_id;//获取查询条件存如Session
            Session["Key"] = s.primarKey;//获取查询条件存如Session
            Session["start"] = s.startDate;//获取查询条件存如Session
            Session["end"] = s.endDate;//获取查询条件存如Session
            return Content("<script>window.location.href='/salaryCriterion/salarystandard_check_list'</script>");//去分页的页面
        }
        #endregion
        #region 薪酬标准登记查询页面
        public ActionResult salarystandard_check_list()//分页也面
        {
            return View();
        }
        #endregion
        #region 薪酬标准登记查询数据
        public ActionResult SelectSQ(int CountIndex, int pageSize)//分页方法
        {
            string id = "0";
            string Key = "0";
            DateTime end = DateTime.Now;//先等于当前时间
            DateTime start = Convert.ToDateTime(Session["start"]);//你的和我不一样因此：判断Session["start"]==null 大于时间就等于 0001-01-01
            //否则就把获取Session
            if (Session["id"] == null)//判断是否有值
            {
                id = "";
            }
            else
            {
                id = Session["id"].ToString();
            }
            if (Session["Key"] == null)//判断是否有值
            {
                Key = "";
            }
            else
            {
                Key = Session["Key"].ToString();
            }
            if (Session["end"] == null)//判断小于时间
            {
                end = DateTime.Now;//没有就获取当前时间
            }
            else
            {
                end = Convert.ToDateTime(Session["end"]);
            }
            Dictionary<int, List<salary_standardModel>> dic1 = ss.FyW(id, Key, start, end, CountIndex, pageSize,3);
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            foreach (KeyValuePair<int, List<salary_standardModel>> item in dic1)
            {
                dic2["dt"] = item.Value;
                dic2["rows"] = item.Key;
                dic2["pages"] = item.Key % pageSize == 0 ? item.Key / pageSize : (item.Key / pageSize) + 1;
            }
            string date = JsonConvert.SerializeObject(dic2);
            return Content(date);
        }
        #endregion
        #region 薪酬标准登记查询数据打印
        [HttpGet]
        public ActionResult salarystandard_query(string id)
        {
            List<salary_standardModel> list = ss.ssAll().Where(e => e.standard_id == id).ToList();
            salary_standardModel s = new salary_standardModel();
            foreach (var item in list)
            {
                s.changer = item.changer;
                s.change_status = item.change_status;
                s.salary_sum = item.salary_sum;
                s.ssd_id = item.ssd_id;
                s.standard_id = item.standard_id;
                s.standard_name = item.standard_name;
                s.check_status = item.check_status;
                s.change_time = item.change_time;
                s.checker = item.checker;
                s.check_comment = item.check_comment;
                s.check_time = item.check_time;
                s.designer = item.designer;
                s.register = item.register;
                s.regist_time = item.regist_time;
                s.remark = item.remark;
                s.lists = issd.ssdAll().Where(e => e.standard_id == item.standard_id).ToList();
            }
            ViewData.Model = s;
            return View();
        }
        #endregion
        #region 薪酬标准变更页面
        [HttpGet]
        public ActionResult salarystandard_query_locate()
        {
            return View();
        }
        #endregion
        #region 薪酬标准变更提交
        [HttpPost]
        public ActionResult salarystandard_query_locate(salary_standardModel s)
        {
            Session["id"] = s.standard_id;
            Session["Key"] = s.primarKey;
            Session["start"] = s.startDate;
            Session["end"] = s.endDate;
            return Content("<script>window.location.href='/salaryCriterion/salarystandard_change_list'</script>");
        }
        #endregion
        #region 薪酬标准变更分页查询页面
        [HttpGet]
        public ActionResult salarystandard_change_list()
        {
            return View();
        }
        #endregion
        #region 薪酬标准变更提交分页查询数据
        public ActionResult SelectBG(int CountIndex, int pageSize)
        {
            string id = "0";
            string Key = "0";
            DateTime end = DateTime.Now;
            DateTime start = Convert.ToDateTime(Session["start"]);
            if (Session["id"] == null)
            {
                id = "";
            }
            else
            {
                id = Session["id"].ToString();
            }
            if (Session["Key"] == null)
            {
                Key = "";
            }
            else
            {
                Key = Session["Key"].ToString();
            }
            if (Session["end"] == null)
            {
                end = DateTime.Now;
            }
            else
            {
                end = Convert.ToDateTime(Session["end"]);
            }
            Dictionary<int, List<salary_standardModel>> dic1 = ss.FyW(id, Key, start, end, CountIndex, pageSize,0);
            Dictionary<string, object> dic2 = new Dictionary<string, object>();
            foreach (KeyValuePair<int, List<salary_standardModel>> item in dic1)
            {
                dic2["dt"] = item.Value;
                dic2["rows"] = item.Key;
                dic2["pages"] = item.Key % pageSize == 0 ? item.Key / pageSize : (item.Key / pageSize) + 1;
            }
            string date = JsonConvert.SerializeObject(dic2);
            return Content(date);
        }
        #endregion
        #region 薪酬标准变更ID详细数据页面
        [HttpGet]
        public ActionResult salarystandard_change(int id)
        {
            NewMethod(id);
            return View();
        }
        #endregion
        #region 薪酬标准变更数据
        [HttpPost]
        public ActionResult salarystandard_change(salary_standardModel ssm)
        {
            ViewBag.Name = Session["Name"];
            ssm.check_status = 1;
            int AK = 0;
                if (ss.ssUpd(ssm) > 0)
                {
                    foreach (var item in ssm.lists)
                    {
                        salary_standard_detailsModel sd = new salary_standard_detailsModel()
                        {
                            standard_id = item.standard_id,
                            standard_name = ssm.standard_name,
                            salary = item.salary,
                            item_id = item.item_id,
                            item_name = item.item_name,
                            sdt_id = item.sdt_id
                        };
                        if (issd.ssdUpd(sd) > 0)
                        {
                            AK++;
                        }
                    }
                }
                if (AK == ssm.lists.Count)
                {
                    return Content("<script>alert('薪酬标准登记变更成功');window.location.href='/salaryCriterion/salarystandard_query_locate'</script>");
                }
                else
                {
                    NewMethod(ssm.ssd_id);
                    return Content("<script>alert('薪酬标准登记变更失败');window.location.href='/salaryCriterion/salarystandard_change'</script>");
                }

        }
        #endregion
        #region 薪酬
        private void NewMethod(int? id)
        {
            string name = Session["Name"].ToString();
            List<salary_standardModel> list = ss.ssAll().Where(e => e.ssd_id == id).ToList();
            salary_standardModel s = new salary_standardModel();
            foreach (var item in list)
            {
                s.changer = name;
                s.change_status = item.change_status;
                s.salary_sum = item.salary_sum;
                s.ssd_id = item.ssd_id;
                s.standard_id = item.standard_id;
                s.standard_name = item.standard_name;
                s.check_status = item.check_status;
                s.change_time = item.change_time;
                s.checker = item.changer;
                s.check_comment = item.check_comment;
                s.check_time = item.check_time;
                s.designer = item.designer;
                s.register = item.register;
                s.regist_time = item.regist_time;
                s.remark = item.remark;
                s.lists = issd.ssdAll().Where(e => e.standard_id == item.standard_id).ToList();
            }
            ViewData.Model = s;
        }
        #endregion
        #endregion
    }
}