using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mUDocter.Business.Models.API
{
    public class PATIENT_INFO
    {
        public int id { get; set; }
        public int user_id { get; set; }

        public int province_id { get; set; }

        public int distrct_id { get; set; }

        public int wards_id { get; set; }

        public string address { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string full_name { get; set; }

        public int sex_id { get; set; }

        public string dob { get; set; }

        public string info_p { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
    }
}
