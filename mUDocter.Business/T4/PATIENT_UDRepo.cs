/*
using System.Collections.Generic;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the PATIENT_UD table in the Main Database.
    /// </summary>
    public class PATIENT_UDRepo
    {
		public static void Save(PATIENT_UD obj)
        {
		    						if (obj.id > 0)
            {
                new MainDB().PATIENT_UD_Update(obj.id, obj.user_id, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.full_name, obj.sex_id, obj.dob, obj.info_p, obj.longitude, obj.latitude, obj.created, obj.status, obj.phone).Execute();
            }
			else
			{
				new MainDB().PATIENT_UD_Insert(obj.user_id, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.full_name, obj.sex_id, obj.dob, obj.info_p, obj.longitude, obj.latitude, obj.created, obj.status, obj.phone).Execute();								
			}			
        }
		public static PATIENT_UD GetByID(int id)
        {
            var list = new MainDB().PATIENT_UD_SelectRow(id).ExecuteTypedList<PATIENT_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<PATIENT_UD> List()
        {
            return new MainDB().PATIENT_UD_SelectAll().ExecuteTypedList<PATIENT_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().PATIENT_UD_DeleteRow(id).Execute();
        }
    } 
}

*/
