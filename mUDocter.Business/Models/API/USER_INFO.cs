using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mUDocter.Business.Models.API
{
    public class USER_INFO
    {
        public int id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int user_type { get; set; }
        public int d_id { get; set; }
        public int p_id { get; set; }
        public int price { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

    }
}
