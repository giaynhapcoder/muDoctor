/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the DICTRCT_UD table in the Main Database.
    /// </summary>
    public class DICTRCT_UDRepo
    {
		public static void Save(DICTRCT_UD obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().DICTRCT_UD_Update(obj.id, obj.province_id, obj.name, obj.orders, obj.created, obj.status, obj.longitude, obj.latitude).Execute();
            }
			else
			{
				new MainDB().DICTRCT_UD_Insert(obj.province_id, obj.name, obj.orders, obj.created, obj.status, obj.longitude, obj.latitude).Execute();								
			}			
        }
		public static DICTRCT_UD GetByID(int id)
        {
            var list = new MainDB().DICTRCT_UD_SelectRow(id).ExecuteTypedList<DICTRCT_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<DICTRCT_UD> List()
        {
            return new MainDB().DICTRCT_UD_SelectAll().ExecuteTypedList<DICTRCT_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().DICTRCT_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
