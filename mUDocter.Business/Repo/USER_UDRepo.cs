using System;
using System.Collections.Generic;
using mUDocter.Business.Models;
using mUDocter.Business.Models.API;

namespace mUDocter.Business.Repo    
{    
    /// <summary>
    /// A class which represents the USER_UD table in the Main Database.
    /// </summary>
    public class USER_UDRepo
    {
        public static USER_UD LOGIN(string user, string pass,int status)
        {
            var list = new MainDB().USER_LOGIN(user, pass, status).ExecuteTypedList<USER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static USER_INFO LOGIN_API(string user, string pass, int status)
        {
            var list = new MainDB().USER_LOGIN_API(user, pass, status).ExecuteTypedList<USER_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static USER_INFO LOGIN_API(string ott_id)
        {
            var list = new MainDB().USER_LOGIN_API_OTT(ott_id).ExecuteTypedList<USER_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static USER_INFO LOGIN_API_BY_ID(int id)
        {
            var list = new MainDB().USER_LOGIN_API_BYID(id).ExecuteTypedList<USER_INFO>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static int Save(USER_UD obj)
        {
		    if (obj.id > 0)
            {
                new MainDB().USER_UD_Update(obj.id, obj.username, obj.password, obj.full_name, obj.address, obj.phone, obj.email, obj.user_type, obj.status).Execute();
            }
			else
			{
                var sp = new MainDB().USER_UD_Insert(obj.username, obj.password, obj.full_name, obj.address, obj.phone, obj.email, obj.user_type, obj.status, obj.facebook_id, obj.gooogle_id);
			    sp.Execute();
                obj.id = Convert.ToInt32(sp.OutputParameters.GetParameter("new_identity").ParameterValue);			
			}
		    return obj.id;
        }
		public static USER_UD GetByID(int id)
        {
            var list = new MainDB().USER_UD_SelectRow(id).ExecuteTypedList<USER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
        public static USER_UD GetByUsername(String username)
        {
            var list = new MainDB().USER_UD_SelectRow_by_username(username).ExecuteTypedList<USER_UD>();
            if (list.Count > 0)
                return list[0];
            return null;
        }
		public static List<USER_UD> List()
        {
            return new MainDB().USER_UD_SelectAll().ExecuteTypedList<USER_UD>();
        }

        public static void Delete(int id)
        {
            new MainDB().USER_UD_DeleteRow(id).Execute();
        }

    } 
}
