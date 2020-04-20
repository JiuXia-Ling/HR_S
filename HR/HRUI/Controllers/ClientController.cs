using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HRIBLL;
using HRModel;
using Newtonsoft.Json;

namespace HRUI.Controllers
{
    public class ClientController : Controller
    {
        public Iconfig_file_first_kindBLL cffk { get; set; }
        public Iconfig_file_second_kindBLL cfsk { get; set; }
        public Iconfig_file_third_kindBLL cftk { get; set; }
        public Iconfig_majorBLL cm { get; set; }
        public Iconfig_major_kindBLL cmk { get; set; }
        public Iconfig_public_charBLL cpc { get; set; }
        // GET: Client
        #region I级机构设置
        #region I级机构设置页面
        public ActionResult first_kind()
        {
            return View();
        }
        #endregion
        #region I级机构设置页面显示
        public async Task<ActionResult> FKSel()
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53063/");
            HttpResponseMessage hrm = await hc.GetAsync("api/config_file_first_kind");
            List<config_file_first_kindModel> list =await hrm.Content.ReadAsAsync<List<config_file_first_kindModel>>();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);
        }
        #endregion
        #region I级机构设置添加页面
        [HttpGet]
        public ActionResult first_kind_register()
        {
            return View();
        }
        #endregion
        #region I级机构设置添加
        [HttpPost]
        public async Task<ActionResult> first_kind_register(config_file_first_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                //产生I级机构编号
                string Max = cffk.cffkAll().Max(e => e.first_kind_id);
                int sum = Convert.ToInt32(Max) + 1;
                if (sum < 10)
                {
                    Max = "0" + sum;
                }
                else
                {
                    Max = sum.ToString(); ;
                }
                ck.first_kind_id = Max;
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:53063/");
                HttpResponseMessage hrm = await hc.PostAsJsonAsync("api/config_file_first_kind",ck);
                int a = await hrm.Content.ReadAsAsync<int>();
                if (a > 0)
                {
                    return Content("<script>alert('I级机构设置添加成功');window.location.href='/Client/first_kind'</script>");
                }
                else
                {
                    return Content("<script>alert('I级机构设置添加失败');window.location.href='/Client/first_kind_register'</script>");
                }
            }
            else
            {
                return View(ck);
            }

        }
        #endregion
        #region I级机构设置更改查询
        [HttpGet]
        public ActionResult first_kind_change(int id)
        {
            List<config_file_first_kindModel> list = cffk.cffkAll().Where(e => e.ffk_id == id).ToList();
            config_file_first_kindModel ck = new config_file_first_kindModel();
            foreach (config_file_first_kindModel item in list)
            {
                ck.ffk_id = item.ffk_id;
                ck.first_kind_id = item.first_kind_id;
                ck.first_kind_name = item.first_kind_name;
                ck.first_kind_salary_id = item.first_kind_salary_id;
                ck.first_kind_sale_id = item.first_kind_sale_id;
            }
            ViewData.Model = ck;
            return View();
        }
        #endregion
        #region I级机构设置更改
        [HttpPost]
        public ActionResult first_kind_change(config_file_first_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                if (cffk.cffkUpd(ck) > 0)
                {
                    return Content("<script>alert('I级机构设置更改成功');window.location.href='/Client/first_kind'</script>");
                }
                else
                {
                    ViewData.Model = ck;
                    return Content("<script>alert('I级机构设置更改失败');window.location.href='/Client/first_kind_change'</script>");
                }
            }
            else
            {
                ViewData.Model = ck;
                return View();
            }
        }
        #endregion
        #region I级机构设置删除
        public async Task<ActionResult> fkDel(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:53063/");
            HttpResponseMessage hrm = await hc.DeleteAsync("api/config_file_first_kind/"+id);
            int num =await hrm.Content.ReadAsAsync<int>(); ;
            return Content(num.ToString());
        }
        #endregion
        #endregion

        #region II级机构设置
        #region II级机构设置页面
        public ActionResult second_kind()
        {
            return View();
        }
        #endregion
        #region II级机构设置页面查询
        public ActionResult Select2()
        {
            List<config_file_second_kindModel> list = cfsk.All();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);

        }
        #endregion
        #region II级机构设置添加页面
        [HttpGet]
        public ActionResult second_kind_register()
        {
            NewMethod();
            return View();
        }
        #endregion
        #region II级机构设置添加
        [HttpPost]
        public ActionResult second_kind_register(config_file_second_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                //获取I级id查name
                List<config_file_first_kindModel> list = cffk.cffkAll().Where(e => e.first_kind_id == ck.first_kind_id).ToList();
                foreach (config_file_first_kindModel item in list)
                {
                    ck.first_kind_name = item.first_kind_name;//给操作表服之
                }
                //产生II级机构编号
                string time = "II" + DateTime.Now.ToString("MMddHHmmss") + "JG";
                ck.second_kind_id = time;
                if (cfsk.FKAdd(ck) > 0)
                {
                    return Content("<script>alert('II级机构设置添加成功');window.location.href='/Client/second_kind'</script>");
                }
                else
                {
                    NewMethod();
                    return Content("<script>alert('II级机构设置添加失败');window.location.href='/Client/second_kind_register'</script>");
                }
            }
            else
            {
                NewMethod();
                return View();
            }
        }
        #endregion
        #region II级机构设置删除
        public ActionResult fskDel(int id)
        {
            config_file_second_kindModel csk = new config_file_second_kindModel();
            csk.fsk_id = id;
            int num = cfsk.FKDelete(csk);
            return Content(num.ToString());
        }
        #endregion
        #region II级机构设置修改查询
        [HttpGet]
        public ActionResult second_kind_change(int id)
        {
            List<config_file_second_kindModel> list = cfsk.All().Where(e => e.fsk_id == id).ToList();
            config_file_second_kindModel ck = new config_file_second_kindModel();
            foreach (config_file_second_kindModel item in list)
            {
                ck.fsk_id = item.fsk_id;
                ck.first_kind_name = item.first_kind_name;
                ck.first_kind_id = item.first_kind_id;
                ck.second_kind_id = item.second_kind_id;
                ck.second_kind_name = item.second_kind_name;
                ck.second_salary_id = item.second_salary_id;
                ck.second_sale_id = item.second_sale_id;
            }
            ViewData.Model = ck;
            return View();
        }
        #endregion
        #region II级机构设置修改
        [HttpPost]
        public ActionResult second_kind_change(config_file_second_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                if (cfsk.FKUpdate(ck) > 0)
                {
                    return Content("<script>alert('II级机构设置更改成功');window.location.href='/Client/second_kind'</script>");
                }
                else
                {
                    ViewData.Model = ck;
                    return Content("<script>alert('II级机构设置更改失败');window.location.href='/Client/second_kind_change'</script>");
                }
            }
            else
            {
                ViewData.Model = ck;
                return View();
            }
        }
        #endregion
        #endregion

        #region III级机构设置
        #region III级机构设置页面
        public ActionResult third_kind()
        {
            return View();
        }
        #endregion
        #region III级机构设置页面查询
        public ActionResult Select3()
        {
            List<config_file_third_kindModel> list = cftk.All();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);
        }
        #endregion
        #region III级机构设置添加页面
        [HttpGet]
        public ActionResult third_kind_register()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "是", Value = "是", Selected = true });
            items.Add(new SelectListItem { Text = "否", Value = "否" });
            ViewData["YN"] = items;
            NewMethod();
            NewMethod1();
            return View();
        }
        #endregion
        #region III级机构设置添加
        [HttpPost]
        public ActionResult third_kind_register(config_file_third_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                ck.first_kind_name = I(ck.first_kind_id);
                ck.second_kind_name = II(ck.second_kind_id);
                //产生II级机构编号
                string time = "III" + DateTime.Now.ToString("MMddHHmmss") + "JG";
                ck.third_kind_id = time;
                if (cftk.KSAdd(ck) > 0)
                {
                    return Content("<script>alert('III级机构设置添加成功');window.location.href='/Client/third_kind'</script>");
                }
                else
                {
                    NewMethod();
                    return Content("<script>alert('III级机构设置添加失败');window.location.href='/Client/third_kind_register'</script>");
                }
            }
            else
            {
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "是", Value = "是", Selected = true });
                items.Add(new SelectListItem { Text = "否", Value = "否" });
                ViewData["YN"] = items;
                NewMethod();
                NewMethod1();
                return View();
            }
        }
        #endregion
        #region III级机构设置修改查询
        [HttpGet]
        public ActionResult third_kind_change(int id)
        {
            List<config_file_third_kindModel> list = cftk.All().Where(e => e.ftk_id == id).ToList();
            config_file_third_kindModel ck = new config_file_third_kindModel();
            foreach (config_file_third_kindModel item in list)
            {
                ck.ftk_id = item.ftk_id;
                ck.first_kind_name = item.first_kind_name;
                ck.first_kind_id = item.first_kind_id;
                ck.second_kind_id = item.second_kind_id;
                ck.second_kind_name = item.second_kind_name;
                ck.third_kind_id = item.third_kind_id;
                ck.third_kind_name = item.third_kind_name;
                ck.third_kind_sale_id = item.third_kind_sale_id;

                ViewData["YN"] = YesNo(item.third_kind_is_retail);//是/否 通用判断方法
            }
            ViewData.Model = ck;
            return View();
        }
        #endregion
        #region III级机构设置修改
        [HttpPost]
        public ActionResult third_kind_change(config_file_third_kindModel ck)
        {
            if (ModelState.IsValid)
            {
                if (cftk.SKUpdate(ck) > 0)
                {
                    return Content("<script>alert('III级机构设置更改成功');window.location.href='/Client/third_kind'</script>");
                }
                else
                {
                    ViewData["YN"] = YesNo(ck.third_kind_is_retail);
                    ViewData.Model = ck;
                    return Content("<script>alert('III级机构设置更改失败');window.location.href='/Client/third_kind_change'</script>");
                }
            }
            else
            {
                ViewData["YN"] = YesNo(ck.third_kind_is_retail);
                ViewData.Model = ck;
                return View();
            }
        }
        #endregion
        #region III级机构设置删除
        public ActionResult skDel(int id)
        {
            config_file_third_kindModel ck = new config_file_third_kindModel();
            ck.ftk_id = id;
            int num = cftk.SKDelete(ck);
            return Content(num.ToString());
        }
        #endregion
        #endregion

        #region 职称设置
        #region 职称设置页面
        public ActionResult profession_design()
        {
            return View();
        }
        #endregion
        #region 职称设置页面查询
        public ActionResult Select4()
        {
            List<config_majorModel> list = cm.cmAll();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);
        }
        #endregion
        #region 职称设置删除
        public ActionResult CMDel(int id)
        {
            config_majorModel c = new config_majorModel();
            c.mak_id = id;
            int num = cm.cmDelete(c);
            return Content(num.ToString());

        }
        #endregion
        #endregion

        #region 职位分类设置
        #region 职位分类设置页面
        public ActionResult major_kind()
        {
            return View();
        }
        #endregion
        #region 职位分类设置查询
        public ActionResult Select5()
        {
            List<config_major_kindModel> list = cmk.cmkAll();
            string date = JsonConvert.SerializeObject(list);
            return Content(date);
        }
        #endregion
        #region 职位分类设置删除
        public ActionResult CMKDel(int id)
        {
            config_major_kindModel c = new config_major_kindModel();
            c.mfk_id = id;
            int num = cmk.cmkDelete(c);
            return Content(num.ToString());

        }
        #endregion
        #region 职位分类设置添加页面
        [HttpGet]
        public ActionResult major_kind_add()
        {
            return View();
        }
        #endregion
        #region 职位分类设置添加
        [HttpPost]
        public ActionResult major_kind_add(config_major_kindModel c)
        {
            if (ModelState.IsValid)
            {
                string a = cmk.cmkAll().Max(e => e.major_kind_id).ToString();
                int major_kind_id = Convert.ToInt32(a) + 1;
                c.major_kind_id = major_kind_id.ToString();
                if (cmk.cmkAdd(c) > 0)
                {
                    return Content("<script>alert('职位分类设置添加成功');window.location.href='/Client/major_kind'</script>");
                }
                else
                {
                    return Content("<script>alert('职位分类设置添加失败');window.location.href='/Client/major_kind_add'</script>");
                }
            }
            else
            {
                return View();
            }
        }
        #endregion
        #endregion

        #region 职称设置2.0
        #region 职称设置2.0页面
        public ActionResult major()
        {
            return View();
        }
        #endregion
        #region 职称设置2.0添加页面
        [HttpGet]
        public ActionResult major_add()
        {
            List<config_major_kindModel> list = cmk.cmkAll();
            SelectList s = new SelectList(list, "major_kind_id ", "major_kind_name");
            ViewData["s"] = s;
            return View();
        }
        #endregion
        #region 职称设置2.0添加
        [HttpPost]
        public ActionResult major_add(config_majorModel c)
        {
            if (ModelState.IsValid)
            {
                List<config_major_kindModel> list = cmk.cmkAll().Where(e => e.major_kind_id == c.major_kind_id).ToList();
                foreach (config_major_kindModel item in list)
                {
                    c.major_kind_name = item.major_kind_name;
                }
                if (cm.cmAdd(c) > 0)
                {
                    return Content("<script>alert('职称设置2.0添加成功');window.location.href='/Client/major'</script>");
                }
                else
                {
                    List<config_major_kindModel> list1 = cmk.cmkAll();
                    SelectList s = new SelectList(list1, "major_kind_id ", "major_kind_name");
                    ViewData["s"] = s;
                    return Content("<script>alert('职称设置2.0添加失败');window.location.href='/Client/major_add'</script>");
                }
            }
            else
            {
                List<config_major_kindModel> list2 = cmk.cmkAll();
                SelectList s = new SelectList(list2, "major_kind_id ", "major_kind_name");
                ViewData["s"] = s;
                return View();
            }
        }
        #endregion
        #endregion

        #region 公共属性设置
        #region 公共属性设置页面
        public ActionResult public_char()
        {
            return View();
        }
        #endregion
        #endregion
        #region 公共属性设置添加页面
        [HttpGet]
        public ActionResult public_char_add()
        {
            return View();
        }
        #endregion
        #region 公共属性设置添加
        [HttpPost]
        public ActionResult public_char_add(config_public_charModel c)
        {
            if (ModelState.IsValid)
            {
                if (cpc.cpcAdd(c) > 0)
                {
                    return Content("<script>alert('公共属性设置添加成功');window.location.href='/Client/major_kind'</script>");
                }
                else
                {
                    return Content("<script>alert('公共属性设置添加失败');window.location.href='/Client/major_kind'</script>");
                }
            }
            else
            {
                return View();
            }

        }
        #endregion
        #region 公共属性设置删除
        [HttpPost]
        public ActionResult cpcDel(int id)
        {
            config_public_charModel c = new config_public_charModel();
            c.pbc_id = id;
            int num = cpc.cpcDelete(c);
            return Content(num.ToString());
        }
        #endregion

        #region 薪酬项目设置
        #region 薪酬项目设置页面
        public ActionResult salary_item()
        {
            return View();
        }
        #endregion
        #endregion

        #region 其他
        #region I信息查询
        public string I(string id)
        {
            List<config_file_first_kindModel> list = cffk.cffkAll().Where(e => e.first_kind_id == id).ToList();
            string first_kind_name = "";
            foreach (config_file_first_kindModel item in list)
            {
                first_kind_name = item.first_kind_name;
            }
            return first_kind_name;
        }
        #endregion
        #region II信息查询
        public string II(string id)
        {
            List<config_file_second_kindModel> list = cfsk.All().Where(e => e.second_kind_id == id).ToList();
            string second_kind_name = "";
            foreach (config_file_second_kindModel item in list)
            {
                second_kind_name = item.second_kind_name;
            }
            return second_kind_name;
        }
        #endregion
        #region Y&&N
        public List<SelectListItem> YesNo(string name)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (name == "是")
            {
                items.Add(new SelectListItem { Text = "是", Value = "是", Selected = true });
                items.Add(new SelectListItem { Text = "否", Value = "否" });
            }
            else
            {
                items.Add(new SelectListItem { Text = "是", Value = "是" });
                items.Add(new SelectListItem { Text = "否", Value = "否", Selected = true });
            }
            return items;
        }
        #endregion
        #region 下拉1
        private void NewMethod()
        {
            List<config_file_first_kindModel> list = cffk.cffkAll();
            SelectList s1 = new SelectList(list, "first_kind_id", "first_kind_name");
            ViewData["s"] = s1;
        }
        #endregion
        #region 下拉2
        private void NewMethod1()
        {
            List<config_file_second_kindModel> list = cfsk.All();
            SelectList s1 = new SelectList(list, "second_kind_id", "second_kind_name");
            ViewData["ss"] = s1;
        }
        #endregion
        #endregion  
    }
}