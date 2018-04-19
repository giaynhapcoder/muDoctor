/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the USER_UD table in the Main Database.
    /// </summary>
    public class USER_UDRepo
    {
		public static void Save(USER_UD obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().USER_UD_Update(obj.id, obj.username, obj.password, obj.full_name, obj.address, obj.phone, obj.email, obj.user_type, obj.status, obj.created, obj.facebook_id, obj.gooogle_id).Execute();
            }
			else
			{
				new MainDB().USER_UD_Insert(obj.username, obj.password, obj.full_name, obj.address, obj.phone, obj.email, obj.user_type, obj.status, obj.created, obj.facebook_id, obj.gooogle_id).Execute();								
			}			
        }
		public static USER_UD GetByID(int id)
        {
            var list = new MainDB().USER_UD_SelectRow(id).ExecuteTypedList<USER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<USER_UD> List()
        {
            return new MainDB().USER_UD_SelectAll().ExecuteTypedList<USER_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().USER_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
