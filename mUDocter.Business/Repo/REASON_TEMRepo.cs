using System.Collections.Generic;
using mUDocter.Business.Models;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo    
{    
    /// <summary>
    /// A class which represents the REASON_TEM table in the Main Database.
    /// </summary>
    public class REASON_TEMRepo
    {
		public static void Save(REASON_TEM obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().REASON_TEM_Update(obj.id, obj.Name, obj.Status).Execute();
            }
			else
			{
				new MainDB().REASON_TEM_Insert(obj.Name, obj.Status).Execute();								
			}			
        }
		public static REASON_TEM GetByID(int id)
        {
            var list = new MainDB().REASON_TEM_SelectRow(id).ExecuteTypedList<REASON_TEM>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<REASON_TEM> List()
        {
            return new MainDB().REASON_TEM_SelectAll().ExecuteTypedList<REASON_TEM>();
        }

        public static List<REASON> List(int stats)
        {
            return new MainDB().REASON_TEM_SelectAll_BY_STT(stats).ExecuteTypedList<REASON>();
        }

        public static void Delete(int id)
        {
            new MainDB().REASON_TEM_DeleteRow(id).Execute();
        }
    } 
}
