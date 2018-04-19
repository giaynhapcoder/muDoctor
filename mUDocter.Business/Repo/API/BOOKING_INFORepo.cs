using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mUDocter.Business.Models.API;


namespace mUDocter.Business.Repo.API
{
    public class BOOKING_INFORepo
    {
        public static List<BOOKING_INFO> GetByDID(int id)
        {
            return new MainDB().BOOKING_INFO_ALL_BY_DOCTER(id).ExecuteTypedList<BOOKING_INFO>();
        }
        public static List<BOOKING_INFO> GetByPID(int id)
        {
            return new MainDB().BOOKING_INFO_ALL_BY_PATIENT(id).ExecuteTypedList<BOOKING_INFO>();
        }
        public static BOOKING_INFO GetByID(int id)
        {
            var list = new MainDB().BOOKING_INFO_ONE_BY_ID(id).ExecuteTypedList<BOOKING_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static List<BOOKING_INFO> GetAll()
        {
            return new MainDB().BOOKING_INFO_ALL().ExecuteTypedList<BOOKING_INFO>();
        }
    }
}
