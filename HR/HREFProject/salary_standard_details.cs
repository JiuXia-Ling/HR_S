using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject
{
    public class salary_standard_details
    {
        public int? sdt_id { get; set; }
        
        public int? item_id { get; set; }
        
        public double? salary { get; set; }
        
        public string standard_id { get; set; }
        
        public string standard_name { get; set; }
        
        public string item_name { get; set; }

        public virtual salar_standard_item salar_standard_item { get; set; }

        public virtual salary_standard salary_standard { get; set; }
    }
}
