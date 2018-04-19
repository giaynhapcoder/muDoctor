/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the SETTING_UD table in the Main Database.
    /// </summary>
    public class SETTING_UDRepo
    {
		public static void Save(SETTING_UD obj)
        {
		    						if (obj.SETTING_KEY > 0)
            {
                new MainDB().SETTING_UD_Update(obj.SETTING_KEY, obj.VALUES_KEY, obj.DES_KEY).Execute();
            }
			else
			{
				new MainDB().SETTING_UD_Insert(obj.VALUES_KEY, obj.DES_KEY).Execute();								
			}			
        }
		public static SETTING_UD GetByID(int id)
        {
            var list = new MainDB().SETTING_UD_SelectRow(id).ExecuteTypedList<SETTING_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<SETTING_UD> List()
        {
            return new MainDB().SETTING_UD_SelectAll().ExecuteTypedList<SETTING_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().SETTING_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
