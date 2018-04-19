using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mUDocter.Business.Models.API
{
    public class DICTRCT
    {
        public int id { get; set; }

        public int province_id { get; set; }

        public string name { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
    }
}
