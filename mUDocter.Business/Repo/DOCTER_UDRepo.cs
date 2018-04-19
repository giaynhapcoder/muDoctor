using System;
using System.Collections.Generic;
using mUDocter.Business.Models;

namespace mUDocter.Business.Repo
{
    /// <summary>
    /// A class which represents the DOCTER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_UDRepo
    {
        public static int Save(DOCTER_UD obj)
        {
            if (obj.id > 0)
            {
                new MainDB().DOCTER_UD_Update(obj.id, obj.user_id, obj.name, obj.dob, obj.sex_id, obj.info_p, obj.hospital, obj.year, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.longitude, obj.latitude, obj.star, obj.status, obj.avartar).Execute();
            }
            else
            {
                var sp = new MainDB().DOCTER_UD_Insert(obj.user_id, obj.name, obj.dob, obj.sex_id, obj.info_p, obj.hospital, obj.year, obj.province_id, obj.distrct_id, obj.wards_id, obj.address, obj.longitude, obj.latitude, obj.star, obj.status, obj.avartar);
                sp.Execute();
                obj.id = Convert.ToInt32(sp.OutputParameters.GetParameter("new_identity").ParameterValue);		
            }

            return obj.id;
        }
        public static DOCTER_UD GetByUID(int id)
        {
            var list = new MainDB().DOCTER_UD_SelectRow_byUID(id).ExecuteTypedList<DOCTER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
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
        public static List<DOCTER_UD> ListByAddress(int district_id, int ward_id)
        {
            return new MainDB().DOCTER_UD_SelectAddress(district_id, ward_id).ExecuteTypedList<DOCTER_UD>();
        }
        public static List<DOCTER_UD> ListByStatus(int status)
        {
            return new MainDB().DOCTER_UD_SelectByStatus(status).ExecuteTypedList<DOCTER_UD>();
        }
    }
}

