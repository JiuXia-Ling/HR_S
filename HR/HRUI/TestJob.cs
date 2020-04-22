using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using HRIBLL;
using HRModel;

namespace HRUI
{
    public class TestJob : IJob
    {
        Ihuman_fileBLL ioc { get; set; }
        public void Execute(IJobExecutionContext context)
        {
            List<human_fileModel> list = ioc.hfAll().Where(e => e.tiem_statu == 1).ToList();
            foreach (var item in list)
            {
                human_fileModel hf = new human_fileModel();
                hf.huf_id = item.huf_id;
                hf.salary_standard_id = item.salary_standard_id;
                hf.first_kind_id = hf.list2.first_kind_id;
                hf.first_kind_name = hf.list2.first_kind_name;
                hf.second_kind_id = hf.list2.second_kind_id;
                hf.second_kind_name = hf.list2.second_kind_name;
                hf.third_kind_id = hf.list2.third_kind_id;
                hf.third_kind_name = hf.list2.third_kind_name;
                hf.human_id = item.human_id;
                hf.human_name = item.human_name;
                hf.salary_standard_id = item.salary_standard_id;
                hf.salary_standard_name = item.salary_standard_name;
                hf.demand_salaray_sum = item.salary_sum;
                hf.salary_sum = item.salary_sum;
                hf.paid_salary_sum = item.paid_salary_sum;
                hf.human_address = item.human_address;
                hf.human_postcode = item.human_postcode;
                hf.human_pro_designation = item.human_pro_designation;
                hf.human_major_kind_id = item.human_major_kind_id;
                hf.human_major_kind_name = item.human_major_kind_name;
                hf.human_major_id = item.human_major_id;
                hf.human_major_name = item.human_major_name;
                hf.human_telephone = item.human_telephone;
                hf.human_mobilephone = item.human_mobilephone;
                hf.human_bank = item.human_bank;
                hf.human_account = item.human_account;
                hf.human_qq = item.human_qq;
                hf.human_email = item.human_email;
                hf.human_hobby = item.human_hobby;
                hf.human_specility = item.human_specility;
                hf.human_sex = item.human_sex;
                hf.human_religion = item.human_religion;
                hf.human_party = item.human_party;
                hf.human_nationality = item.human_nationality;
                hf.human_race = item.human_race;
                hf.human_birthday = item.human_birthday;
                hf.human_birthplace = item.human_birthplace;
                hf.human_age = item.human_age;
                hf.human_educated_degree = item.human_educated_degree;
                hf.human_educated_years = item.human_educated_years;
                hf.human_educated_major = item.human_educated_major;
                hf.human_society_security_id = item.human_society_security_id;
                hf.human_idcard = item.human_idcard;
                hf.remark = item.remark;
                hf.salary_standard_id = item.salary_standard_id;
                hf.salary_standard_name = item.salary_standard_name;
                hf.major_change_amount = item.major_change_amount;
                hf.bonus_amount = item.bonus_amount;
                hf.training_amount = item.training_amount;
                hf.file_chang_amount = item.file_chang_amount;
                hf.human_histroy_records = item.human_histroy_records;
                hf.human_family_membership = item.human_family_membership;
                hf.human_picture = item.human_picture;
                hf.attachment_name = item.attachment_name;
                hf.check_status = item.check_status;
                hf.register = item.register;
                hf.checker = item.checker;
                hf.changer = item.changer;
                hf.regist_time = item.regist_time;
                hf.check_time = item.check_time;
                hf.change_time = item.change_time;
                hf.lastly_change_time = item.lastly_change_time;
                hf.delete_time = item.delete_time;
                hf.recovery_time = item.recovery_time;
                hf.human_file_status = item.human_file_status;
                hf.tiem_statu = 0;
                ioc.hfUpd(hf);
            }
        }
    }
}