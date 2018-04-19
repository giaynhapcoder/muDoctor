using System.Collections.Generic;
using mUDocter.Business.Models;

namespace mUDocter.Business.Repo    
{    
    /// <summary>
    /// A class which represents the PROVINCE_UD table in the Main Database.
    /// </summary>
    public class PROVINCE_UDRepo
    {
		public static void Save(PROVINCE_UD obj)
        {
		    if (obj.id > 0)
            {
                new MainDB().PROVINCE_UD_Update(obj.id, obj.name, obj.orders, obj.status).Execute();
            }
			else
			{
				new MainDB().PROVINCE_UD_Insert(obj.name, obj.orders, obj.status).Execute();								
			}			
        }
		public static PROVINCE_UD GetByID(int id)
        {
            var list = new MainDB().PROVINCE_UD_SelectRow(id).ExecuteTypedList<PROVINCE_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<PROVINCE_UD> List()
        {
            return new MainDB().PROVINCE_UD_SelectAll().ExecuteTypedList<PROVINCE_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().PROVINCE_UD_DeleteRow(id).Execute();
        }
    } 
}
