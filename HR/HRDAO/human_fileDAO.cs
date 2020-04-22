using HREFProject;
using HRIDAO;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDAO
{
    public class human_fileDAO : BaseDao<human_file>, Ihuman_fileDAO
    {
        public int hfAdd(human_fileModel item)
        {
            human_file hf = new human_file()
            {
                huf_id = item.huf_id,
                human_id = item.human_id,
                first_kind_id = item.first_kind_id,
                first_kind_name = item.first_kind_name,
                second_kind_id = item.second_kind_id,
                second_kind_name = item.second_kind_name,
                third_kind_id = item.third_kind_id,
                third_kind_name = item.third_kind_name,
                human_name = item.human_name,
                human_address = item.human_address,
                human_postcode = item.human_postcode,
                human_pro_designation = item.human_pro_designation,
                human_major_kind_id = item.human_major_kind_id,
                human_major_kind_name = item.human_major_kind_name,
                human_major_id = item.human_major_id,
                human_major_name = item.human_major_name,
                human_telephone = item.human_telephone,
                human_mobilephone = item.human_mobilephone,
                human_bank = item.human_bank,
                human_account = item.human_account,
                human_qq = item.human_qq,
                human_email = item.human_email,
                human_hobby = item.human_hobby,
                human_specility = item.human_specility,
                human_sex = item.human_sex,
                human_religion = item.human_religion,
                human_party = item.human_party,
                human_nationality = item.human_nationality,
                human_race = item.human_race,
                human_birthday = item.human_birthday,
                human_birthplace = item.human_birthplace,
                human_age = item.human_age,
                human_educated_degree = item.human_educated_degree,
                human_educated_years = item.human_educated_years,
                human_educated_major = item.human_educated_major,
                human_society_security_id = item.human_society_security_id,
                human_idcard = item.human_idcard,
                remark = item.remark,
                salary_standard_id = item.salary_standard_id,
                salary_standard_name = item.salary_standard_name,
                salary_sum = item.salary_sum,
                demand_salaray_sum = item.demand_salaray_sum,
                paid_salary_sum = item.paid_salary_sum,
                major_change_amount = item.major_change_amount,
                bonus_amount = item.bonus_amount,
                training_amount = item.training_amount,
                file_chang_amount = item.file_chang_amount,
                human_histroy_records = item.human_histroy_records,
                human_family_membership = item.human_family_membership,
                human_picture = item.human_picture,
                attachment_name = item.attachment_name,
                check_status = item.check_status,
                register = item.register,
                checker = item.checker,
                changer = item.changer,
                regist_time = item.regist_time,
                check_time = item.check_time,
                change_time = item.change_time,
                lastly_change_time = item.lastly_change_time,
                delete_time = item.delete_time,
                recovery_time = item.recovery_time,
                human_file_status = item.human_file_status,
                tiem_statu = item.tiem_statu
            };
            return Add(hf);
        }

        public List<human_fileModel> hfAll()
        {
            List<human_file> list1 = select();
            List<human_fileModel> list2 = new List<human_fileModel>();
            foreach (human_file item in list1)
            {
                human_fileModel hf = new human_fileModel()
                {
                    huf_id = item.huf_id,
                    human_id = item.human_id,
                    first_kind_id = item.first_kind_id,
                    first_kind_name = item.first_kind_name,
                    second_kind_id = item.second_kind_id,
                    second_kind_name = item.second_kind_name,
                    third_kind_id = item.third_kind_id,
                    third_kind_name = item.third_kind_name,
                    human_name = item.human_name,
                    human_address = item.human_address,
                    human_postcode = item.human_postcode,
                    human_pro_designation = item.human_pro_designation,
                    human_major_kind_id = item.human_major_kind_id,
                    human_major_kind_name = item.human_major_kind_name,
                    human_major_id = item.human_major_id,
                    human_major_name = item.human_major_name,
                    human_telephone = item.human_telephone,
                    human_mobilephone = item.human_mobilephone,
                    human_bank = item.human_bank,
                    human_account = item.human_account,
                    human_qq = item.human_qq,
                    human_email = item.human_email,
                    human_hobby = item.human_hobby,
                    human_specility = item.human_specility,
                    human_sex = item.human_sex,
                    human_religion = item.human_religion,
                    human_party = item.human_party,
                    human_nationality = item.human_nationality,
                    human_race = item.human_race,
                    human_birthday = item.human_birthday,
                    human_birthplace = item.human_birthplace,
                    human_age = item.human_age,
                    human_educated_degree = item.human_educated_degree,
                    human_educated_years = item.human_educated_years,
                    human_educated_major = item.human_educated_major,
                    human_society_security_id = item.human_society_security_id,
                    human_idcard = item.human_idcard,
                    remark = item.remark,
                    salary_standard_id = item.salary_standard_id,
                    salary_standard_name = item.salary_standard_name,
                    salary_sum = item.salary_sum,
                    demand_salaray_sum = item.demand_salaray_sum,
                    paid_salary_sum = item.paid_salary_sum,
                    major_change_amount = item.major_change_amount,
                    bonus_amount = item.bonus_amount,
                    training_amount = item.training_amount,
                    file_chang_amount = item.file_chang_amount,
                    human_histroy_records = item.human_histroy_records,
                    human_family_membership = item.human_family_membership,
                    human_picture = item.human_picture,
                    attachment_name = item.attachment_name,
                    check_status = item.check_status,
                    register = item.register,
                    checker = item.checker,
                    changer = item.changer,
                    regist_time = item.regist_time,
                    check_time = item.check_time,
                    change_time = item.change_time,
                    lastly_change_time = item.lastly_change_time,
                    delete_time = item.delete_time,
                    recovery_time = item.recovery_time,
                    human_file_status = item.human_file_status,
                    tiem_statu=item.tiem_statu
                };
                list2.Add(hf);
            }
            return list2;
        }

        public int hfDel(human_fileModel hf)
        {
            human_file h = new human_file()
            {
                huf_id = hf.huf_id
            };
            return Delete(h);
        }

        public int hfUpd(human_fileModel item)
        {
            human_file hf = new human_file()
            {
                huf_id = item.huf_id,
                human_id = item.human_id,
                first_kind_id = item.first_kind_id,
                first_kind_name = item.first_kind_name,
                second_kind_id = item.second_kind_id,
                second_kind_name = item.second_kind_name,
                third_kind_id = item.third_kind_id,
                third_kind_name = item.third_kind_name,
                human_name = item.human_name,
                human_address = item.human_address,
                human_postcode = item.human_postcode,
                human_pro_designation = item.human_pro_designation,
                human_major_kind_id = item.human_major_kind_id,
                human_major_kind_name = item.human_major_kind_name,
                human_major_id = item.human_major_id,
                human_major_name = item.human_major_name,
                human_telephone = item.human_telephone,
                human_mobilephone = item.human_mobilephone,
                human_bank = item.human_bank,
                human_account = item.human_account,
                human_qq = item.human_qq,
                human_email = item.human_email,
                human_hobby = item.human_hobby,
                human_specility = item.human_specility,
                human_sex = item.human_sex,
                human_religion = item.human_religion,
                human_party = item.human_party,
                human_nationality = item.human_nationality,
                human_race = item.human_race,
                human_birthday = item.human_birthday,
                human_birthplace = item.human_birthplace,
                human_age = item.human_age,
                human_educated_degree = item.human_educated_degree,
                human_educated_years = item.human_educated_years,
                human_educated_major = item.human_educated_major,
                human_society_security_id = item.human_society_security_id,
                human_idcard = item.human_idcard,
                remark = item.remark,
                salary_standard_id = item.salary_standard_id,
                salary_standard_name = item.salary_standard_name,
                salary_sum = item.salary_sum,
                demand_salaray_sum = item.demand_salaray_sum,
                paid_salary_sum = item.paid_salary_sum,
                major_change_amount = item.major_change_amount,
                bonus_amount = item.bonus_amount,
                training_amount = item.training_amount,
                file_chang_amount = item.file_chang_amount,
                human_histroy_records = item.human_histroy_records,
                human_family_membership = item.human_family_membership,
                human_picture = item.human_picture,
                attachment_name = item.attachment_name,
                check_status = item.check_status,
                register = item.register,
                checker = item.checker,
                changer = item.changer,
                regist_time = item.regist_time,
                check_time = item.check_time,
                change_time = item.change_time,
                lastly_change_time = item.lastly_change_time,
                delete_time = item.delete_time,
                recovery_time = item.recovery_time,
                human_file_status = item.human_file_status,
                tiem_statu = item.tiem_statu
            };
            return Upd(hf);
        }
    }
}
