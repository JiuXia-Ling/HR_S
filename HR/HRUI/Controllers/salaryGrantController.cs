using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRModel;
using HRIBLL;
using System.Xml.Linq;
using System.Collections;
using Newtonsoft.Json;

namespace HRUI.Controllers
{
    public class salaryGrantController : Controller
    {
        public Ihuman_fileBLL Ihd { get; set; }
        public Iconfig_file_first_kindBLL icffk { get; set; }
        public Iconfig_file_second_kindBLL icfsk { get; set; }
        public Iconfig_file_third_kindBLL icftk { get; set; }
        public Isalary_standard_detailsBLL ssd { get; set; }
        public Isalary_standardBLL ss { get; set; }
        public Isalary_grantBLL sg { get; set; }
        public Isalary_grant_detailsBLL sgd { get; set; }
        // GET: salaryGrant
        #region  薪酬发放登记方式
        public ActionResult register_locate()
        {
            return View();
        }
        #endregion
        #region 薪酬发放登记根据获取的等级机构查询数据
        [HttpPost]
        public ActionResult register_list()
        {
            var a = Request.Form["submitType"];
            List<register_listModel> lists = new List<register_listModel>();
            int counts = 0;
            decimal? moneys = 0;
            decimal? Fmoneys = 0;
            if (a == "1")
            {
                List<config_file_first_kindModel> I = icffk.cffkAll();
                List <human_fileModel> list = Ihd.hfAll().Where(e => e.second_kind_name== null && e.third_kind_name == null&& e.check_status == 2.ToString() && e.tiem_statu == 0).ToList();
                for (int i = 0; i < I.Count; i++)
                {
                    List<human_fileModel> list1 = list.Where(e => e.first_kind_id == I[i].first_kind_id).ToList();
                    if (list1.Count > 0)
                    {
                        register_listModel ll = new register_listModel();
                        List<string> sid = new List<string>();
                        ll.id = list1[0].first_kind_id;
                        ll.name = list1[0].first_kind_name;
                        ll.count = list1.Count;
                        foreach (var item in list1)
                        {
                            sid.Add(item.human_id);
                            ll.money = item.salary_sum * list1.Count;//基本薪酬总数
                            moneys += item.salary_sum;
                            Fmoneys += item.paid_salary_sum;
                        }
                        ll.sid = sid;
                        lists.Add(ll);
                        counts += list1.Count;//总人数
                    }
                }
                ViewBag.I = "I";
                Session["I"] = "I";
            }
            else if(a == "2")
            {
                List<config_file_second_kindModel> I = icfsk.All();
                List<human_fileModel> list = Ihd.hfAll().Where(e => e.third_kind_name == null && e.check_status == 2.ToString() && e.tiem_statu == 0).ToList();
                for (int i = 0; i < I.Count; i++)
                {
                    List<human_fileModel> list1 = list.Where(e => e.second_kind_id == I[i].second_kind_id).ToList();
                    if (list1.Count > 0)
                    {
                        register_listModel ll = new register_listModel();
                        List<string> sid = new List<string>();
                        ll.id = list1[0].second_kind_id;
                        ll.name = list1[0].second_kind_name;
                        ll.count = list1.Count;
                        foreach (var item in list1)
                        {
                            sid.Add(item.human_id);
                            ll.money = item.salary_sum * list1.Count;
                            moneys += item.salary_sum;
                            Fmoneys += item.paid_salary_sum;
                        }
                        ll.sid = sid;
                        lists.Add(ll);
                        counts += list1.Count;
                    }

                }
                ViewBag.I = "II";
                Session["I"] = "II";
            }
            else
            {
                List<config_file_third_kindModel> I = icftk.All();
                List<human_fileModel> list = Ihd.hfAll().Where(e=>e.check_status=="2" && e.tiem_statu == 0).ToList();
                for (int i = 0; i < I.Count; i++)
                {
                    List<human_fileModel> list1 = list.Where(e => e.third_kind_id == I[i].third_kind_id).ToList();
                    if (list1.Count > 0)
                    {
                        register_listModel ll = new register_listModel();
                        List<string> sid = new List<string>();
                        ll.id = list1[0].third_kind_id;
                        ll.name = list1[0].third_kind_name;
                        ll.count = list1.Count;
                        foreach (var item in list1)
                        {
                            sid.Add(item.human_id);
                            ll.money = item.salary_sum * list1.Count;
                            moneys += item.salary_sum;
                            Fmoneys += item.paid_salary_sum;
                        }
                        ll.sid = sid;
                        lists.Add(ll);
                        counts += list1.Count;
                    }
                }
                ViewBag.I = "III";
                Session["I"] = "III";
            }
            ViewBag.counts = counts;//人数
            ViewBag.moneys = moneys;//金额
            ViewBag.lt = lists;
            ViewBag.nums = lists.Count;//总记录数
            ViewBag.Fmoneys = Fmoneys;
            return View();
        }
#endregion
        #region 薪酬发放登记数据查询(负责人控制)
        [HttpGet]
        public ActionResult register_commit(string id)
        {
            string FBH = sg.salary_grantAll().Max(e => e.salary_grant_id);//获取salary_grant表中最大的salary_grant_id
            if (FBH == null)
            {
                FBH = "FBH" + DateTime.Now.ToString("yyyyMMdd") +"00"+ 1;
            }
            else
            {
                int a = Convert.ToInt32(FBH.Substring(11));
                if (a<10)
                {
                    FBH = "FBH" + DateTime.Now.ToString("yyyyMMdd") + "00" + (a + 1);
                }
                else if (a<100)
                {

                    FBH = "FBH" + DateTime.Now.ToString("yyyyMMdd") + "0" + (a + 1);
                }
            }
            Session["Human_Id"] = id;
            string[] sid = id.Split(',');
            List<human_fileModel> lists = new List<human_fileModel>();
            var num = 0;
            decimal? money = 0;
            decimal? Fmoneys = 0;
            var BH = "";
            for (int i = 0; i < sid.Length; i++)
            {
                List<human_fileModel> list = Ihd.hfAll().Where(e => e.human_id == sid[i].ToString()).ToList();
                foreach (var item in list)
                {
                    human_fileModel hf = new human_fileModel()
                    {
                        huf_id = item.huf_id,
                        human_id = item.human_id,
                        demand_salaray_sum = item.demand_salaray_sum,
                        human_name = item.human_name,
                        first_kind_id = item.first_kind_id,
                        first_kind_name = item.first_kind_name,
                        paid_salary_sum = item.paid_salary_sum,
                        salary_standard_id = item.salary_standard_id,
                        salary_standard_name = item.salary_standard_name,
                        salary_sum = item.salary_sum,
                        second_kind_id = item.second_kind_id,
                        second_kind_name = item.second_kind_name,
                        third_kind_id = item.third_kind_id,
                        third_kind_name = item.third_kind_name,
                    };
                    money += item.salary_sum;
                    Fmoneys += item.paid_salary_sum;
                    num++;
                    BH = item.salary_standard_id;
                    lists.Add(hf);
                }
            }
            if (Session["I"].ToString() == "I")
            {
                ViewBag.I = lists[0].first_kind_name;
            }
            else if(Session["I"].ToString() == "II")
            {
                ViewBag.I = lists[0].second_kind_name;
            }
            else
            {
                ViewBag.I = lists[0].third_kind_name;
            }
            ViewBag.BH = BH;
            ViewBag.Nums = num;
            ViewBag.Money = money;
           ViewBag.Name = Session["Name"];
            ViewBag.LT = lists;
            ViewBag.Count = lists.Count;
            ViewBag.Fmoneys = Fmoneys;
            ViewBag.FBH = FBH;
            return PartialView();
        }
#endregion
        #region 薪酬发放登记
        [HttpPost]
        public ActionResult register_commit(human_fileModel hf)
        {
            int count = 0;
            hf.list2.check_status = 0;
            foreach (var item in hf.list1)
            {
                List<human_fileModel> list = Ihd.hfAll().Where(e => e.human_id == item.human_id).ToList();
                List<salary_standardModel> list1 = ss.ssAll().Where(e => e.standard_id == item.salary_standard_id).ToList();
                hf.huf_id = list[0].huf_id;
                hf.demand_salaray_sum = item.salary_paid_sum;
                hf.first_kind_id = hf.list2.first_kind_id;
                hf.first_kind_name = hf.list2.first_kind_name;
                hf.second_kind_id = hf.list2.second_kind_id;
                hf.second_kind_name = hf.list2.second_kind_name;
                hf.third_kind_id = hf.list2.third_kind_id;
                hf.third_kind_name = hf.list2.third_kind_name;
                hf.human_id = item.human_id;
                hf.human_name = item.human_name;
                hf.salary_standard_id = item.salary_standard_id;
                hf.salary_standard_name = list1[0].standard_name;
                hf.demand_salaray_sum = list1[0].salary_sum;
                hf.salary_sum = list1[0].salary_sum;
                hf.paid_salary_sum = item.salary_paid_sum;
                hf.human_address = list[0].human_address;
                hf.human_postcode = list[0].human_postcode;
                hf.human_pro_designation = list[0].human_pro_designation;
                hf.human_major_kind_id = list[0].human_major_kind_id;
                hf.human_major_kind_name = list[0].human_major_kind_name;
                hf.human_major_id = list[0].human_major_id;
                hf.human_major_name = list[0].human_major_name;
                hf.human_telephone = list[0].human_telephone;
                hf.human_mobilephone = list[0].human_mobilephone;
                hf.human_bank = list[0].human_bank;
                hf.human_account = list[0].human_account;
                hf.human_qq = list[0].human_qq;
                hf.human_email = list[0].human_email;
                hf.human_hobby = list[0].human_hobby;
                hf.human_specility = list[0].human_specility;
                hf.human_sex = list[0].human_sex;
                hf.human_religion = list[0].human_religion;
                hf.human_party = list[0].human_party;
                hf.human_nationality = list[0].human_nationality;
                hf.human_race = list[0].human_race;
                hf.human_birthday = list[0].human_birthday;
                hf.human_birthplace = list[0].human_birthplace;
                hf.human_age = list[0].human_age;
                hf.human_educated_degree = list[0].human_educated_degree;
                hf.human_educated_years = list[0].human_educated_years;
                hf.human_educated_major = list[0].human_educated_major;
                hf.human_society_security_id = list[0].human_society_security_id;
                hf.human_idcard = list[0].human_idcard;
                hf.remark = list[0].remark;
                hf.salary_standard_id = list[0].salary_standard_id;
                hf.salary_standard_name = list[0].salary_standard_name;
                hf.major_change_amount = list[0].major_change_amount;
                hf.bonus_amount = list[0].bonus_amount;
                hf.training_amount = list[0].training_amount;
                hf.file_chang_amount = list[0].file_chang_amount;
                hf.human_histroy_records = list[0].human_histroy_records;
                hf.human_family_membership = list[0].human_family_membership;
                hf.human_picture = list[0].human_picture;
                hf.attachment_name = list[0].attachment_name;
                hf.check_status = list[0].check_status;
                hf.register = list[0].register;
                hf.checker = list[0].checker;
                hf.changer = list[0].changer;
                hf.regist_time = list[0].regist_time;
                hf.check_time = list[0].check_time;
                hf.change_time = list[0].change_time;
                hf.lastly_change_time = list[0].lastly_change_time;
                hf.delete_time = list[0].delete_time;
                hf.recovery_time = list[0].recovery_time;
                hf.human_file_status = list[0].human_file_status;
                hf.tiem_statu =1;
                Ihd.hfUpd(hf);
            }//foreach循环对人力资源档案对应数据做修改
            int SGNum = sg.salary_grantAdd(hf.list2);
            foreach (var item1 in hf.list1)
            {
                salary_grant_detailsModel s = new salary_grant_detailsModel()
                {
                    salary_grant_id = hf.list2.salary_grant_id,
                    salary_paid_sum = item1.salary_paid_sum,
                    salary_standard_sum = item1.salary_standard_sum,
                    sale_sum = item1.sale_sum,
                    bouns_sum = item1.bouns_sum,
                    deduct_sum = item1.deduct_sum,
                    human_id = item1.human_id,
                    human_name = item1.human_name,
                    salary_standard_id = item1.salary_standard_id
                };
                if (sgd.salary_grant_detailsAdd(s) > 0)
                {
                    count++;
                }
            }
            if (count == hf.list1.Count)
            {
                return Content("<script>alert('薪酬发放登记成功，待复核');window.location.href='/salaryGrant/register_locate'</script>");
            }
            else
            {
                return Content("<script>alert('薪酬发放登记失败');window.location.href='/salaryGrant/register_locate/'+" + Session["Human_Id"] + "</script>");
            }
        }
        #endregion
        #region 薪酬发放登记审核
        [HttpGet]
        public ActionResult check_list()
        {
            return View();
        }
        #endregion
        #region 薪酬发放登记复核数据查询
        public ActionResult SelectSG(int CountIndex, int pageSize)
        {
            int rows = 0;
            string where = "check_status !=2";
            List<salary_grantModel> list = sg.salary_grantFy("", CountIndex, pageSize,"",ref rows,where);
            Dictionary<string, object> dic= new Dictionary<string, object>();
            dic["dt"] = list;
            dic["rows"] = rows;
            dic["pages"] = rows % pageSize == 0 ? rows / pageSize : (rows / pageSize) + 1;
            string date = JsonConvert.SerializeObject(dic);
            return Content(date);
        }
        #endregion
        #region 薪资基本明细
        public ActionResult ById(string salary_standard_id)
        {
            List<salary_standard_detailsModel> list = ssd.ssdAll().Where(e => e.standard_id == salary_standard_id).ToList();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);
        }
        #endregion
        #region 薪酬发放复核页面数据
        [HttpGet]
        public ActionResult check(string id)
        {
            decimal? money = 0;
            decimal? Fmoneys = 0;
            List<salary_grant_detailsModel> list = sgd.salary_grant_detailsAll().Where(e => e.salary_grant_id == id).ToList();
            List<salary_grantModel> sgs=sg.salary_grantAll().Where(e => e.salary_grant_id == id).ToList();
            if (sgs[0].second_kind_name==null&&sgs[0].third_kind_name==null)
            {
                ViewBag.JG = sgs[0].first_kind_name;
            }
            else if (sgs[0].third_kind_name == null)
            {
                ViewBag.JG = sgs[0].second_kind_name;
            }
            else
            {
                ViewBag.JG = sgs[0].third_kind_name;
            }
            var BH = list[0].salary_grant_id;
            foreach (var item in list)
            {
                money += item.salary_standard_sum;
                Fmoneys += item.salary_paid_sum;
            }
            ViewBag.Count = list.Count;
            ViewBag.Money = money;
            ViewBag.Fmoneys = Fmoneys;
            ViewBag.LT = list;
            ViewBag.BH = BH;
            return View();
        }
        #endregion
        #region 薪酬发放复核通过
        [HttpPost]
        public ActionResult check(salary_grantModel Sgm)
        {
            List<salary_grantModel> list = sg.salary_grantAll().Where(e => e.salary_grant_id == Sgm.salary_grant_id).ToList();
            salary_grantModel s = new salary_grantModel();
            foreach (var item in list)
            {
                s.sgr_id = item.sgr_id;
                s.checker = Sgm.checker;
                s.check_status =2;
                s.check_time = Sgm.check_time;
                s.first_kind_id = item.first_kind_id;
                s.first_kind_name = item.first_kind_name;
                s.human_amount = item.human_amount;
                s.register = item.register;
                s.regist_time = item.regist_time;
                s.salary_grant_id = item.salary_grant_id;
                s.salary_paid_sum = Sgm.salary_paid_sum;
                s.salary_standard_sum = item.salary_standard_sum;
                s.second_kind_id = item.second_kind_id;
                s.second_kind_name = item.second_kind_name;
                s.third_kind_id = item.third_kind_id;
                s.third_kind_name = item.third_kind_name;
            }
            int Num = 0;
            if (sg.salary_grantUpd(s) > 0)
            {
                foreach (var item in Sgm.list1)
                {
                    salary_grant_detailsModel sm = new salary_grant_detailsModel()
                    {
                        grd_id = item.grd_id,
                        salary_grant_id = item.salary_grant_id,
                        salary_paid_sum = item.salary_paid_sum,
                        salary_standard_sum = item.salary_standard_sum,
                        sale_sum = item.sale_sum,
                        bouns_sum = item.bouns_sum,
                        deduct_sum = item.deduct_sum,
                        human_id = item.human_id,
                        human_name = item.human_name,
                        salary_standard_id = item.salary_standard_id
                    };
                    if (sgd.salary_grant_detailsUpd(sm) > 0)
                    {
                        Num++;
                    }
                }
            }
            if (Num == Sgm.list1.Count)
            {
                return Content("<script>alert('薪酬发放复核成功');window.location.href='/salaryGrant/check_list'</script>");
            }
            else
            {
                return Content("<script>alert('薪酬发放复核失败');window.location.href='/salaryGrant/check/'+" + Sgm.salary_grant_id + "</script>");
            }
        }
        #endregion
        #region 薪酬发放查询
        [HttpGet]
        public ActionResult query_locate()
        {
            return View();
        }
        #endregion
        #region 薪酬发放查询页面及条件
        public ActionResult query_list()
        {
            Session["SG_Bh"] = Request.Form["salaryGrantId"];
            Session["SG_Gjz"] = Request.Form["primarKey"];
            Session["SG_State"] = Request.Form["startDate"];
            Session["SG_End"] = Request.Form["endDate"];
            return View();
        }
        #endregion
        #region MyRegion
        [HttpPost]
        public ActionResult SelectSGId()
        {
            int CountIndex = Convert.ToInt32(Request["CountIndex"]);
            int pageSize = Convert.ToInt32(Request["pageSize"]);
            int rows = 0;
            string where = "1=1";
            string salary_grant_id = "";
            string Gjz = "";
            string state = Session["SG_State"].ToString();
            string end =Session["SG_End"].ToString();
            DateTime Time_State = Convert.ToDateTime("0001-01-01");
            DateTime Time_End = DateTime.Now;
            if (Session["SG_Bh"]!=null)
            {
                salary_grant_id = Session["SG_Bh"].ToString();
            }
            if (Session["SG_Gjz"] != null)
            {
                Gjz = Session["SG_Gjz"].ToString();
            }
            if (state!="")
            {
                Time_State = Convert.ToDateTime(Session["SG_State"]);
            }
            if (end != "")
            {
                Time_End = Convert.ToDateTime(Session["SG_End"]);
            }
            List<salary_grantModel> list = new List<salary_grantModel>();
            if (Gjz == "")
            {
                where = $"regist_time>= {Time_State.ToString("yyyy-MM-dd")} AND regist_time<='{Time_End.ToString("yyyy-MM-dd")}' AND salary_grant_id like '%{salary_grant_id}%' AND  check_status=2";
                list = sg.salary_grantFy("", CountIndex, pageSize, "", ref rows, where);
            }
            else
            {
                if (list.Count == 0)
                {
                    where = $"regist_time>= {Time_State.ToString("yyyy-MM-dd")} AND regist_time<='{Time_End.ToString("yyyy-MM-dd")}' AND salary_grant_id like '%{salary_grant_id}%' AND  check_status=2 And first_kind_name like '%{Gjz}%' ";
                    list = sg.salary_grantFy("", CountIndex, pageSize, "", ref rows, where);//一级机构
                    if (list.Count == 0)
                    {
                        where = $"regist_time>= {Time_State.ToString("yyyy-MM-dd")} AND regist_time<='{Time_End.ToString("yyyy-MM-dd")}' AND salary_grant_id like '%{salary_grant_id}%' AND  check_status=2 And second_kind_name like '%{Gjz}%' ";
                        list = sg.salary_grantFy("", CountIndex, pageSize, "", ref rows, where);//二级机构
                        if (list.Count == 0)
                        {
                            where = $"regist_time>= {Time_State.ToString("yyyy-MM-dd")} AND regist_time<='{Time_End.ToString("yyyy-MM-dd")}' AND salary_grant_id like '%{salary_grant_id}%' AND  check_status=2 And third_kind_name like '%{Gjz}%' ";
                            list = sg.salary_grantFy("", CountIndex, pageSize, "", ref rows, where);//三级机构
                        }
                    }
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["dt"] = list;
            dic["rows"] = list.Count;
            dic["pages"] = rows % pageSize == 0 ? rows / pageSize : (rows / pageSize) + 1;
            string date = JsonConvert.SerializeObject(dic);
            return Content(date);
        }
        #endregion
        #region MyRegion
        [HttpGet]
        public ActionResult query(string id)
        {
            decimal? money = 0;
            decimal? Fmoneys = 0;
            List<salary_grant_detailsModel> list = sgd.salary_grant_detailsAll().Where(e => e.salary_grant_id == id).ToList();
            List<salary_grantModel> sgs = sg.salary_grantAll().Where(e => e.salary_grant_id == id).ToList();
            if (sgs[0].second_kind_name == null && sgs[0].third_kind_name == null)
            {
                ViewBag.JG = sgs[0].first_kind_name;
            }
            else if (sgs[0].third_kind_name == null)
            {
                ViewBag.JG = sgs[0].second_kind_name;
            }
            else
            {
                ViewBag.JG = sgs[0].third_kind_name;
            }
            var BH = list[0].salary_grant_id;
            foreach (var item in list)
            {
                money += item.salary_standard_sum;
                Fmoneys += item.salary_paid_sum;
            }
            ViewBag.Count = list.Count;
            ViewBag.Money = money;
            ViewBag.Fmoneys = Fmoneys;
            ViewBag.LT = list;
            ViewBag.BH = BH;
            ViewBag.Check_Name = sgs[0].register;
            ViewBag.Check_Time = Convert.ToDateTime(sgs[0].regist_time).ToString("yyyy-MM-dd");
            return View();
        }
        #endregion
    }
}