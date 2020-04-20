using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject
{
    public class human_file
    {
        public short? huf_id { get; set; }//主键
        public string human_id { get; set; }//档案编号
        public string first_kind_id { get; set; }//一级机构编号
        public string first_kind_name { get; set; }//一级机构名称
        public string second_kind_id { get; set; }//二级机构编号
        public string second_kind_name { get; set; }//二级机构名称
        public string third_kind_id { get; set; }//三级机构编号
        public string third_kind_name { get; set; }//三级机构名称
        public string human_name { get; set; }//姓名
        public string salary_standard_id { get; set; }//薪酬标准编号
        public string salary_standard_name { get; set; }//薪酬标准名称
        public decimal? salary_sum { get; set; }//基本薪酬总额
        public decimal? demand_salaray_sum { get; set; }//应发薪酬总额
        public decimal? paid_salary_sum { get; set; }//实发薪酬总额
        public int? check_status { get; set; }//复核状态
    }
}
