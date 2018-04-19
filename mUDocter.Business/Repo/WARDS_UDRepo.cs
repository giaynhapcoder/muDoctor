using System.Collections.Generic;
using mUDocter.Business.Models;

namespace mUDocter.Business.Repo
{
    /// <summary>
    /// A class which represents the WARDS_UD table in the Main Database.
    /// </summary>
    public class WARDS_UDRepo
    {
        public static void Save(WARDS_UD obj)
        {
            if (obj.id > 0)
            {
                new MainDB().WARDS_UD_Update(obj.id, obj.dictrct_id, obj.name, obj.orders, obj.status).Execute();
            }
            else
            {
                new MainDB().WARDS_UD_Insert(obj.dictrct_id, obj.name, obj.orders, obj.status).Execute();
            }
        }
        public static WARDS_UD GetByID(int id)
        {
            var list = new MainDB().WARDS_UD_SelectRow(id).ExecuteTypedList<WARDS_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static List<WARDS_UD> List()
        {
            return new MainDB().WARDS_UD_SelectAll().ExecuteTypedList<WARDS_UD>();
        }
        public static List<WARDS_UD> List(int dictrct_id)
        {
            return new MainDB().WARDS_UD_SelectAll_BY_DICTRCT(dictrct_id).ExecuteTypedList<WARDS_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().WARDS_UD_DeleteRow(id).Execute();
        }
    }
}
