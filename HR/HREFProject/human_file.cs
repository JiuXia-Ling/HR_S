using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject
{
    public class human_file
    {
        public int huf_id { get; set; }
        public string human_id { get; set; }
        public string first_kind_id { get; set; }
        public string first_kind_name { get; set; }
        public string second_kind_id { get; set; }
        public string second_kind_name { get; set; }
        public string third_kind_id { get; set; }
        public string third_kind_name { get; set; }
        public string human_name { get; set; }
        public string human_address { get; set; }
        public string human_postcode { get; set; }
        public string human_pro_designation { get; set; }
        public string human_major_kind_id { get; set; }
        public string human_major_kind_name { get; set; }
        public string human_major_id { get; set; }
        public string human_major_name { get; set; }
        public string human_telephone { get; set; }
        public string human_homephone { get; set; }
        public string human_mobilephone { get; set; }
        public string human_bank { get; set; }
        public string human_account { get; set; }
        public string human_qq { get; set; }
        public string human_email { get; set; }
        public string human_hobby { get; set; }
        public string human_specility { get; set; }
        public string human_sex { get; set; }
        public string human_religion { get; set; }
        public string human_party { get; set; }
        public string human_nationality { get; set; }
        public string human_race { get; set; }
        public DateTime? human_birthday { get; set; }
        public string human_birthplace { get; set; }
        public string human_age { get; set; }
        public string human_educated_degree { get; set; }
        public string human_educated_years { get; set; }
        public string human_educated_major { get; set; }
        public string human_society_security_id { get; set; }
        public string human_idcard { get; set; }
        public string remark { get; set; }
        public string salary_standard_id { get; set; }
        public string salary_standard_name { get; set; }
        public decimal? salary_sum { get; set; }
        public decimal? demand_salaray_sum { get; set; }
        public decimal? paid_salary_sum { get; set; }
        public short major_change_amount { get; set; }
        public short bonus_amount { get; set; }
        public short training_amount { get; set; }
        public short file_chang_amount { get; set; }
        public string human_histroy_records { get; set; }
        public string human_family_membership { get; set; }
        public string human_picture { get; set; }
        public string attachment_name { get; set; }
        public string check_status { get; set; }
        public string register { get; set; }
        public string checker { get; set; }
        public string changer { get; set; }
        public DateTime? regist_time { get; set; }
        public DateTime? check_time { get; set; }
        public DateTime? change_time { get; set; }
        public DateTime? lastly_change_time { get; set; }
        public DateTime? delete_time { get; set; }
        public DateTime? recovery_time { get; set; }
        public Boolean human_file_status { get; set; }
        public int? tiem_statu { get; set; }//当月工资状态
    }
}
