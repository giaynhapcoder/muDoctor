using System.Collections.Generic;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo.API
{
    public class DOCTER_INFORepo
    {

        public static List<DOCTER_INFO> List(int status)
        {
            return new MainDB().GET_ALL_DOCTER_INFO_UID(status).ExecuteTypedList<DOCTER_INFO>();
        }
        public static DOCTER_INFO GetByUID(int id)
        {
            var list = new MainDB().DOCTER_INFO_byUID(id).ExecuteTypedList<DOCTER_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static DOCTER_INFO GetByID(int id)
        {
            var list = new MainDB().DOCTER_UD_SelectRow(id).ExecuteTypedList<DOCTER_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
    }
}
