using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class salary_grantModel
    {
        public int sgr_id { get; set; }
        
        public int? human_amount { get; set; }
        
        public int? check_status { get; set; }
        
        public decimal? salary_standard_sum { get; set; }
        
        public decimal? salary_paid_sum { get; set; }
        
        public DateTime? regist_time { get; set; }
        
        public DateTime? check_time { get; set; }
        
        public string salary_grant_id { get; set; }
        
        public string first_kind_name { get; set; }
        
        public string second_kind_name { get; set; }
        
        public string third_kind_name { get; set; }
        
        public string register { get; set; }
        
        public string checker { get; set; }
        
        public string first_kind_id { get; set; }
        
        public string second_kind_id { get; set; }
        
        public string third_kind_id { get; set; }

        public List<salary_grant_detailsModel> list1 { get; set; }
    }
}
