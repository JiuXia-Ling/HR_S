using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class salary_standard_detailsModel
    {
        public int? sdt_id { get; set; }
        
        public int? item_id { get; set; }

        [Required(ErrorMessage = "请输入金额")]
        public double? salary { get; set; }
        
        public string standard_id { get; set; }
        
        public string standard_name { get; set; }
        
        public string item_name { get; set; }

        public virtual salar_standard_itemModel salar_standard_item { get; set; }

        public virtual salary_standardModel salary_standard { get; set; }
    }
}
