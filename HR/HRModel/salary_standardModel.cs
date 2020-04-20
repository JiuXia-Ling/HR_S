using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class salary_standardModel
    {
        public string check_comment { get; set; }
        
        public string remark { get; set; }
        
        public int? check_status { get; set; }
        
        public int? change_status { get; set; }
        
        public int? ssd_id { get; set; }
        
        public decimal? salary_sum { get; set; }
        
        public DateTime? regist_time { get; set; }
        
        public DateTime? check_time { get; set; }
        
        public DateTime? change_time { get; set; }
        
        public string standard_id { get; set; }

        [Required(ErrorMessage = "请输入薪酬标准名称")]
        public string standard_name { get; set; }
        
        public string designer { get; set; }
        
        public string register { get; set; }
        
        public string checker { get; set; }
        
        public string changer { get; set; }

        public bool AddCustomer { get; set; }

        public List<salar_standard_itemModel> list { get; set; }

        public List<salary_standard_detailsModel> lists { get; set; }

        public string primarKey { get; set; }//关键字
        
        public DateTime? startDate { get; set; }//建档时间

        public string endDate { get; set; }//建档时间
        
    }
}
