using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRModel
{
    public class register_listModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public int count { get; set; }

        public decimal? money { get; set; }

        public List<string> sid { get; set; }
    }
}
