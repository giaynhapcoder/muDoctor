/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the DOCTER_IN_SER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_IN_SER_UDRepo
    {
		public static void Save(DOCTER_IN_SER_UD obj)
        {
		    						if (obj.docter_id > 0)
            {
                new MainDB().DOCTER_IN_SER_UD_Update(obj.docter_id, obj.service_id, obj.price).Execute();
            }
			else
			{
				new MainDB().DOCTER_IN_SER_UD_Insert(obj.service_id, obj.price).Execute();								
			}			
        }
		public static DOCTER_IN_SER_UD GetByID(int id)
        {
            var list = new MainDB().DOCTER_IN_SER_UD_SelectRow(id).ExecuteTypedList<DOCTER_IN_SER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<DOCTER_IN_SER_UD> List()
        {
            return new MainDB().DOCTER_IN_SER_UD_SelectAll().ExecuteTypedList<DOCTER_IN_SER_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().DOCTER_IN_SER_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
