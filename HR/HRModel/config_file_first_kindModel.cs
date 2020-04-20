using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class config_file_first_kindModel
    {
        private string _first_kind_salary_id;
        [Required(ErrorMessage = " 薪酬发放责任人编号不能为空")]
        public string first_kind_salary_id
        {
            get { return _first_kind_salary_id; }
            set { _first_kind_salary_id = value; }
        }

        private string _first_kind_sale_id;
        [Required(ErrorMessage = "销售责任人编号不能为空")]
        public string first_kind_sale_id
        {
            get { return _first_kind_sale_id; }
            set { _first_kind_sale_id = value;}
        }

        private int _ffk_id;
        public int ffk_id
        {
            get { return _ffk_id; }
            set { _ffk_id = value; }
        }

        private string _first_kind_name;
        [Required(ErrorMessage = "I级机构名称不能为空")]
        public string first_kind_name
        {
            get { return _first_kind_name; }
            set { _first_kind_name = value;  }
        }

        private string _first_kind_id;
        public string first_kind_id
        {
            get { return _first_kind_id; }
            set { _first_kind_id = value;}
        }


    }
}
