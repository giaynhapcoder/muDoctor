using System.Collections.Generic;
using mUDocter.Business.Models;

namespace mUDocter.Business.Repo    
{    
    /// <summary>
    /// A class which represents the DOCTER_IN_SER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_IN_SER_UDRepo
    {
		public static void Save(DOCTER_IN_SER_UD obj)
        {
		    new MainDB().DOCTER_IN_SER_UD_Insert(obj.docter_id, obj.service_id, obj.price).Execute();					
        }
		public static List<DOCTER_IN_SER_UD> List(int docter_id)
        {
            return new MainDB().DOCTER_IN_SER_UD_SelectAll(docter_id).ExecuteTypedList<DOCTER_IN_SER_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().DOCTER_IN_SER_UD_DeleteRow(id).Execute();
        }
    } 
}