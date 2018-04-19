/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the SERVICE_UD table in the Main Database.
    /// </summary>
    public class SERVICE_UDRepo
    {
		public static void Save(SERVICE_UD obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().SERVICE_UD_Update(obj.id, obj.name, obj.dec, obj.orders, obj.created, obj.status).Execute();
            }
			else
			{
				new MainDB().SERVICE_UD_Insert(obj.name, obj.dec, obj.orders, obj.created, obj.status).Execute();								
			}			
        }
		public static SERVICE_UD GetByID(int id)
        {
            var list = new MainDB().SERVICE_UD_SelectRow(id).ExecuteTypedList<SERVICE_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<SERVICE_UD> List()
        {
            return new MainDB().SERVICE_UD_SelectAll().ExecuteTypedList<SERVICE_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().SERVICE_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
