using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HREFProject;
using HRModel;

namespace HRApi.Controllers
{
    public class config_file_first_kindController : ApiController
    {
        HRDbContext db = new HRDbContext();
        [HttpGet]
        public List<config_file_first_kindModel> Getconfig_file_first_kind()
        {
            List<config_file_first_kind> list= db.config_file_first_kind.ToList();
            List<config_file_first_kindModel> lists = new List<config_file_first_kindModel>();
            foreach (var item in list)
            {
                config_file_first_kindModel ck = new config_file_first_kindModel()
                {
                    ffk_id = item.ffk_id,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    first_kind_salary_id=item.first_kind_salary_id,
                    first_kind_sale_id=item.first_kind_sale_id
                };
                lists.Add(ck);
            }
            return lists;
        }
        [HttpDelete]
        public async Task<int> Deleteconfig_file_first_kind(int id) {
            config_file_first_kind c = new config_file_first_kind();
            c.ffk_id = id;
            db.Set<config_file_first_kind>().Attach(c);
            db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
            int num =await db.SaveChangesAsync();
            return num;
        }

        [HttpPost]
        public async Task<int> Postconfig_file_first_kind(config_file_first_kind ck)
        {
            db.config_file_first_kind.Add(ck);
            int num = await db.SaveChangesAsync();
            return num;
        }

    }
}
