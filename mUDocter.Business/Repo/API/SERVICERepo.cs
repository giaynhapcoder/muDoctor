using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mUDocter.Business.Models;

namespace mUDocter.Business.Repo.API
{
    public class SERVICERepo
    {
        public static List<SERVICE_INFO> List(int d_id)
        {
            return new MainDB().GET_API_SERVICE_IN_DID(d_id).ExecuteTypedList<SERVICE_INFO>();
        }
    }
}
