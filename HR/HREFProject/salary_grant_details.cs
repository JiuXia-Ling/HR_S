using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject
{
    public class salary_grant_details
    {
        public int grd_id { get; set; }
        
        public decimal? bouns_sum { get; set; }
        
        public decimal? sale_sum { get; set; }
        
        public decimal? deduct_sum { get; set; }
        
        public decimal? salary_standard_sum { get; set; }
        
        public decimal? salary_paid_sum { get; set; }
        
        public string salary_grant_id { get; set; }
        
        public string human_id { get; set; }
        
        public string human_name { get; set; }

        public string salary_standard_id { get; set; }
    }
}
