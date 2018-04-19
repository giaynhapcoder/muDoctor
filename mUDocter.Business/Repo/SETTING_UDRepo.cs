using System.Collections.Generic;
using mUDocter.Business.Models;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo    
{    
    /// <summary>
    /// A class which represents the SETTING_UD table in the Main Database.
    /// </summary>
    public class SETTING_UDRepo
    {
		public static void Save(SETTING_UD obj, int up)
        {
            if (up == 1)
            {
                new MainDB().SETTING_UD_Update(obj.SETTING_KEY, obj.VALUES_KEY, obj.DES_KEY).Execute();
            }
			else
			{
				new MainDB().SETTING_UD_Insert(obj.SETTING_KEY, obj.VALUES_KEY, obj.DES_KEY).Execute();								
			}			
        }
		public static SETTING_UD GetByID(string id)
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
        public static List<SETTING_INFO> ListAPI()
        {
            return new MainDB().SETTING_UD_SelectAll().ExecuteTypedList<SETTING_INFO>();
        }

        public static void Delete(string id)
        {
            new MainDB().SETTING_UD_DeleteRow(id).Execute();
        }
    } 
}
