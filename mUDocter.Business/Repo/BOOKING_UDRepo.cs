using System;
using System.Collections.Generic;
using mUDocter.Business.Models;


namespace mUDocter.Business.Repo
{
    /// <summary>
    /// A class which represents the BOOKING_UD table in the Main Database.
    /// </summary>
    public class BOOKING_UDRepo
    {
        public static int Save(BOOKING_UD obj)
        {
            if (obj.id > 0)
            {
                new MainDB().BOOKING_UD_Update(obj.id, obj.patient_id, obj.docter_id, obj.time_in, obj.longitude, obj.latitude, obj.comment, obj.status, obj.tam_date, obj.vs_date, obj.rate, obj.date_time).Execute();
            }
            else
            {
                var sp = new MainDB().BOOKING_UD_Insert(obj.patient_id, obj.docter_id, obj.time_in, obj.longitude, obj.latitude, obj.comment, obj.status, obj.tam_date, obj.vs_date, obj.date_time);
            
                sp.Execute();
                obj.id = Convert.ToInt32(sp.OutputParameters.GetParameter("new_identity").ParameterValue);
            }
            return obj.id;
        }
        public static BOOKING_UD GetByID(int id)
        {
            var list = new MainDB().BOOKING_UD_SelectRow(id).ExecuteTypedList<BOOKING_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static List<BOOKING_UD> List()
        {
            return new MainDB().BOOKING_UD_SelectAll().ExecuteTypedList<BOOKING_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().BOOKING_UD_DeleteRow(id).Execute();
        }
    }
}
