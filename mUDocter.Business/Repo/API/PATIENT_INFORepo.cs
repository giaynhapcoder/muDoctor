using System.Collections.Generic;
using mUDocter.Business.Models;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo.API
{
    public class PATIENT_INFORepo
    {


        public static PATIENT_INFO GetByUID(int id)
        {
            var list = new MainDB().PATIENT_UD_SelectRow_BYUID(id).ExecuteTypedList<PATIENT_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        
    }
}
