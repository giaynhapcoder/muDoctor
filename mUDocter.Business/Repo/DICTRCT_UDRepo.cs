using System;
using System.Collections.Generic;
using mUDocter.Business.Enums;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo
{
    /// <summary>
    /// A class which represents the DICTRCT_UD table in the Main Database.
    /// </summary>
    public class DICTRCT_UDRepo
    {
        public static void Save(DICTRCT_UD obj)
        {
            if (obj.id > 0)
            {
                new MainDB().DICTRCT_UD_Update(obj.id, obj.province_id, obj.name, obj.orders, obj.status, obj.longitude, obj.latitude).Execute();
            }
            else
            {
                new MainDB().DICTRCT_UD_Insert(obj.province_id, obj.name, obj.orders, obj.status, obj.longitude, obj.latitude).Execute();
            }
        }
        public static DICTRCT_UD GetByID(int id)
        {
            var list = new MainDB().DICTRCT_UD_SelectRow(id).ExecuteTypedList<DICTRCT_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static List<DICTRCT> ListActive()
        {
            return new MainDB().DICTRCT_UD_SELECT_ACTIVE((int)StatusGlobal.Activate).ExecuteTypedList<DICTRCT>();
        }
        public static List<DICTRCT_UD> List()
        {
            return new MainDB().DICTRCT_UD_SelectAll().ExecuteTypedList<DICTRCT_UD>();
        }
        public static List<DICTRCT_UD> List(int privice_id)
        {
            return new MainDB().DICTRCT_UD_SelectAll_by_Province(privice_id).ExecuteTypedList<DICTRCT_UD>();
        }

        public static List<DICTRCT_UD> List(int province_id, int pageIndex, int pageSize, out int totalRows)
        {
            var sp = new MainDB().DISTRICT_ALL_BY_PROVINCE(province_id, pageIndex, pageSize);

            var list = sp.ExecuteTypedList<DICTRCT_UD>();

            //var prms = sp.Command.Parameters;
            totalRows = Convert.ToInt32(sp.OutputParameters.GetParameter("TotalRows").ParameterValue);

            return list;
        }

        public static void Delete(int id)
        {
            new MainDB().DICTRCT_UD_DeleteRow(id).Execute();
        }
    }
}