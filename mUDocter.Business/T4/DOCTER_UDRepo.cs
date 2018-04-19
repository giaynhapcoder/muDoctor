

















/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the DOCTER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_UDRepo
    {
		public static void Save(DOCTER_UD obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().DOCTER_UD_Update(obj.id, obj.user_id, obj.name, obj.dob, obj.sex_id, obj.info_p, obj.hospital, obj.year, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.longitude, obj.latitude, obj.star, obj.created, obj.status, obj.avartar, obj.phone).Execute();
            }
			else
			{
				new MainDB().DOCTER_UD_Insert(obj.user_id, obj.name, obj.dob, obj.sex_id, obj.info_p, obj.hospital, obj.year, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.longitude, obj.latitude, obj.star, obj.created, obj.status, obj.avartar, obj.phone).Execute();								
			}			
        }
		public static DOCTER_UD GetByID(int id)
        {
            var list = new MainDB().DOCTER_UD_SelectRow(id).ExecuteTypedList<DOCTER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<DOCTER_UD> List()
        {
            return new MainDB().DOCTER_UD_SelectAll().ExecuteTypedList<DOCTER_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().DOCTER_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
