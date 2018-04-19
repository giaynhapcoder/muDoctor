
















  
using System;
using SubSonic.Schema;
using System.Data;
namespace mUDocter.Business{
	public partial class MainDB{

        public StoredProcedure BOOKING_INFO_ALL(){
            var sp=new StoredProcedure("BOOKING_INFO_ALL",Provider);
            return sp;
        }
        public StoredProcedure BOOKING_INFO_ALL_BY_DOCTER(int? docter_id){
            var sp=new StoredProcedure("BOOKING_INFO_ALL_BY_DOCTER",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure BOOKING_INFO_ALL_BY_PATIENT(int? patient_id){
            var sp=new StoredProcedure("BOOKING_INFO_ALL_BY_PATIENT",Provider);
				sp.Command.AddParameter("patient_id", patient_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure BOOKING_INFO_ONE_BY_ID(int? id){
            var sp=new StoredProcedure("BOOKING_INFO_ONE_BY_ID",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure BOOKING_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("BOOKING_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure BOOKING_UD_Insert(int? patient_id,int? docter_id,DateTime? time_in,double? longitude,double? latitude,string comment,int? status,int? tam_date,int? vs_date,string date_time){
            var sp=new StoredProcedure("BOOKING_UD_Insert",Provider);
				sp.Command.AddParameter("patient_id", patient_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("time_in", time_in,DbType.DateTime,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("comment", comment,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("tam_date", tam_date,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("vs_date", vs_date,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("date_time", date_time,DbType.String,ParameterDirection.Input);
					
	
				sp.Command.AddOutputParameter("new_identity",DbType.Int32);
				
            return sp;
        }

        public StoredProcedure BOOKING_UD_SelectAll(){
            var sp=new StoredProcedure("BOOKING_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure BOOKING_UD_SelectRow(int? id){
            var sp=new StoredProcedure("BOOKING_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure BOOKING_UD_Update(int? id,int? patient_id,int? docter_id,DateTime? time_in,double? longitude,double? latitude,string comment,int? status,int? tam_date,int? vs_date,double? rate,string date_time){
            var sp=new StoredProcedure("BOOKING_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("patient_id", patient_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("time_in", time_in,DbType.DateTime,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("comment", comment,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("tam_date", tam_date,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("vs_date", vs_date,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("rate", rate,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("date_time", date_time,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("DICTRCT_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_Insert(int? province_id,string name,int? orders,int? status,double? longitude,double? latitude){
            var sp=new StoredProcedure("DICTRCT_UD_Insert",Provider);
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_SELECT_ACTIVE(int? status){
            var sp=new StoredProcedure("DICTRCT_UD_SELECT_ACTIVE",Provider);
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_SelectAll(){
            var sp=new StoredProcedure("DICTRCT_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure DICTRCT_UD_SelectAll_by_Province(int? province_id){
            var sp=new StoredProcedure("DICTRCT_UD_SelectAll_by_Province",Provider);
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_SelectRow(int? id){
            var sp=new StoredProcedure("DICTRCT_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DICTRCT_UD_Update(int? id,int? province_id,string name,int? orders,int? status,double? longitude,double? latitude){
            var sp=new StoredProcedure("DICTRCT_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DISTRICT_ALL_BY_PROVINCE(int? province_id,int? PageIndex,int? PageSize){
            var sp=new StoredProcedure("DISTRICT_ALL_BY_PROVINCE",Provider);
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("PageIndex", PageIndex,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("PageSize", PageSize,DbType.Int32,ParameterDirection.Input);
					
	
				sp.Command.AddOutputParameter("TotalRows",DbType.Int32);
				
            return sp;
        }
        public StoredProcedure DOCTER_IN_SER_UD_DeleteRow(int? docter_id){
            var sp=new StoredProcedure("DOCTER_IN_SER_UD_DeleteRow",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_IN_SER_UD_Insert(int? docter_id,int? service_id,int? price){
            var sp=new StoredProcedure("DOCTER_IN_SER_UD_Insert",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("service_id", service_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("price", price,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_IN_SER_UD_SelectAll(int? docter_id){
            var sp=new StoredProcedure("DOCTER_IN_SER_UD_SelectAll",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }

        public StoredProcedure DOCTER_UD_SelectByStatus(int? status)
        {
            var sp = new StoredProcedure(" DOCTER_UD_SelectByStatus", Provider);
            sp.Command.AddParameter("status", status, DbType.Int32, ParameterDirection.Input);

            return sp;
        }


        internal StoredProcedure DOCTER_UD_SelectAddress(int? district_id, int? ward_id)
        {
            var sp = new StoredProcedure("DOCTER_UD_SelectAddress", Provider);
            sp.Command.AddParameter("district_id",  district_id, DbType.Int32, ParameterDirection.Input);
            sp.Command.AddParameter("ward_id", ward_id, DbType.Int32, ParameterDirection.Input);
            return sp;
        }



        public StoredProcedure DOCTER_IN_SER_UD_SelectRow(int? docter_id,int? service_id){
            var sp=new StoredProcedure("DOCTER_IN_SER_UD_SelectRow",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("service_id", service_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_INFO_byUID(int? user_id){
            var sp=new StoredProcedure("DOCTER_INFO_byUID",Provider);
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("DOCTER_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_UD_Insert(int? user_id,string name,string dob,int? sex_id,string info_p,string hospital,int? year,int? province_id,int? distrct_id,int? wards_id,string address,double? longitude,double? latitude,int? star,int? status,string avartar){
            var sp=new StoredProcedure("DOCTER_UD_Insert",Provider);
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("dob", dob,DbType.AnsiString,ParameterDirection.Input);
					
				sp.Command.AddParameter("sex_id", sex_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("info_p", info_p,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("hospital", hospital,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("year", year,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("distrct_id", distrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("wards_id", wards_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("star", star,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("avartar", avartar,DbType.String,ParameterDirection.Input);
					
	
				sp.Command.AddOutputParameter("new_identity",DbType.Int32);
				
            return sp;
        }
        public StoredProcedure DOCTER_UD_SelectAll(){
            var sp=new StoredProcedure("DOCTER_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure DOCTER_UD_SelectRow(int? id){
            var sp=new StoredProcedure("DOCTER_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_UD_SelectRow_byUID(int? user_id){
            var sp=new StoredProcedure("DOCTER_UD_SelectRow_byUID",Provider);
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure DOCTER_UD_Update(int? id,int? user_id,string name,string dob,int? sex_id,string info_p,string hospital,int? year,int? province_id,int? distrct_id,int? wards_id,string address,double? longitude,double? latitude,int? star,int? status,string avartar){
            var sp=new StoredProcedure("DOCTER_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("dob", dob,DbType.AnsiString,ParameterDirection.Input);
					
				sp.Command.AddParameter("sex_id", sex_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("info_p", info_p,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("hospital", hospital,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("year", year,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("distrct_id", distrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("wards_id", wards_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("star", star,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("avartar", avartar,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure GET_ALL_DOCTER_INFO_UID(int? status){
            var sp=new StoredProcedure("GET_ALL_DOCTER_INFO_UID",Provider);
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure GET_API_SERVICE_IN_DID(int? docter_id){
            var sp=new StoredProcedure("GET_API_SERVICE_IN_DID",Provider);
				sp.Command.AddParameter("docter_id", docter_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PATIENT_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("PATIENT_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PATIENT_UD_Insert(int? user_id,int? province_id,int? distrct_id,int? wards_id,string address,string full_name,int? sex_id,string dob,string info_p,double? longitude,double? latitude,int? status,string phone){
            var sp=new StoredProcedure("PATIENT_UD_Insert",Provider);
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("distrct_id", distrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("wards_id", wards_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("full_name", full_name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("sex_id", sex_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("dob", dob,DbType.AnsiString,ParameterDirection.Input);
					
				sp.Command.AddParameter("info_p", info_p,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("phone", phone,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PATIENT_UD_SelectAll(){
            var sp=new StoredProcedure("PATIENT_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure PATIENT_UD_SelectRow(int? id){
            var sp=new StoredProcedure("PATIENT_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PATIENT_UD_SelectRow_BYUID(int? u_id){
            var sp=new StoredProcedure("PATIENT_UD_SelectRow_BYUID",Provider);
				sp.Command.AddParameter("u_id", u_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PATIENT_UD_Update(int? id,int? user_id,int? province_id,int? distrct_id,int? wards_id,string address,string full_name,int? sex_id,string dob,string info_p,double? longitude,double? latitude,int? status,string phone){
            var sp=new StoredProcedure("PATIENT_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("user_id", user_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("province_id", province_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("distrct_id", distrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("wards_id", wards_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("full_name", full_name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("sex_id", sex_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("dob", dob,DbType.AnsiString,ParameterDirection.Input);
					
				sp.Command.AddParameter("info_p", info_p,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("longitude", longitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("latitude", latitude,DbType.Double,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("phone", phone,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PROVINCE_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("PROVINCE_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PROVINCE_UD_Insert(string name,int? orders,int? status){
            var sp=new StoredProcedure("PROVINCE_UD_Insert",Provider);
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PROVINCE_UD_SelectAll(){
            var sp=new StoredProcedure("PROVINCE_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure PROVINCE_UD_SelectRow(int? id){
            var sp=new StoredProcedure("PROVINCE_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure PROVINCE_UD_Update(int? id,string name,int? orders,int? status){
            var sp=new StoredProcedure("PROVINCE_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SERVICE_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("SERVICE_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SERVICE_UD_Insert(string name,string dec,int? orders,int? status){
            var sp=new StoredProcedure("SERVICE_UD_Insert",Provider);
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("dec", dec,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SERVICE_UD_SelectAll(){
            var sp=new StoredProcedure("SERVICE_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure SERVICE_UD_SelectRow(int? id){
            var sp=new StoredProcedure("SERVICE_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SERVICE_UD_Update(int? id,string name,string dec,int? orders,int? status){
            var sp=new StoredProcedure("SERVICE_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("dec", dec,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_LOGIN(string username,string password,int? status){
            var sp=new StoredProcedure("USER_LOGIN",Provider);
				sp.Command.AddParameter("username", username,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("password", password,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_LOGIN_API(string username,string password,int? status){
            var sp=new StoredProcedure("USER_LOGIN_API",Provider);
				sp.Command.AddParameter("username", username,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("password", password,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_LOGIN_API_BYID(int? id){
            var sp=new StoredProcedure("USER_LOGIN_API_BYID",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_LOGIN_API_OTT(string ott_id){
            var sp=new StoredProcedure("USER_LOGIN_API_OTT",Provider);
				sp.Command.AddParameter("ott_id", ott_id,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("USER_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_UD_Insert(string username,string password,string full_name,string address,string phone,string email,int? user_type,int? status,string facebook_id,string gooogle_id){
            var sp=new StoredProcedure("USER_UD_Insert",Provider);
				sp.Command.AddParameter("username", username,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("password", password,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("full_name", full_name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("phone", phone,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("email", email,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("user_type", user_type,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("facebook_id", facebook_id,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("gooogle_id", gooogle_id,DbType.String,ParameterDirection.Input);
					
	
				sp.Command.AddOutputParameter("new_identity",DbType.Int32);
				
            return sp;
        }
        public StoredProcedure USER_UD_SelectAll(){
            var sp=new StoredProcedure("USER_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure USER_UD_SelectRow(int? id){
            var sp=new StoredProcedure("USER_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_UD_SelectRow_by_username(string username){
            var sp=new StoredProcedure("USER_UD_SelectRow_by_username",Provider);
				sp.Command.AddParameter("username", username,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure USER_UD_Update(int? id,string username,string password,string full_name,string address,string phone,string email,int? user_type,int? status){
            var sp=new StoredProcedure("USER_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("username", username,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("password", password,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("full_name", full_name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("address", address,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("phone", phone,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("email", email,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("user_type", user_type,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure WARDS_UD_DeleteRow(int? id){
            var sp=new StoredProcedure("WARDS_UD_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure WARDS_UD_Insert(int? dictrct_id,string name,int? orders,int? status){
            var sp=new StoredProcedure("WARDS_UD_Insert",Provider);
				sp.Command.AddParameter("dictrct_id", dictrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure WARDS_UD_SelectAll(){
            var sp=new StoredProcedure("WARDS_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure WARDS_UD_SelectAll_BY_DICTRCT(int? dictrct_id){
            var sp=new StoredProcedure("WARDS_UD_SelectAll_BY_DICTRCT",Provider);
				sp.Command.AddParameter("dictrct_id", dictrct_id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure WARDS_UD_SelectRow(int? id){
            var sp=new StoredProcedure("WARDS_UD_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure WARDS_UD_Update(int? id,int? dictrct_id,string name,int? orders,int? status){
            var sp=new StoredProcedure("WARDS_UD_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("dictrct_id", dictrct_id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("name", name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("orders", orders,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("status", status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure REASON_TEM_DeleteRow(int? id){
            var sp=new StoredProcedure("REASON_TEM_DeleteRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure REASON_TEM_Insert(string Name,int? Status){
            var sp=new StoredProcedure("REASON_TEM_Insert",Provider);
				sp.Command.AddParameter("Name", Name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("Status", Status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure REASON_TEM_SelectAll(){
            var sp=new StoredProcedure("REASON_TEM_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure REASON_TEM_SelectAll_BY_STT(int? Status){
            var sp=new StoredProcedure("REASON_TEM_SelectAll_BY_STT",Provider);
				sp.Command.AddParameter("Status", Status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure REASON_TEM_SelectRow(int? id){
            var sp=new StoredProcedure("REASON_TEM_SelectRow",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure REASON_TEM_Update(int? id,string Name,int? Status){
            var sp=new StoredProcedure("REASON_TEM_Update",Provider);
				sp.Command.AddParameter("id", id,DbType.Int32,ParameterDirection.Input);
					
				sp.Command.AddParameter("Name", Name,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("Status", Status,DbType.Int32,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SETTING_UD_DeleteRow(string SETTING_KEY){
            var sp=new StoredProcedure("SETTING_UD_DeleteRow",Provider);
				sp.Command.AddParameter("SETTING_KEY", SETTING_KEY,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SETTING_UD_Insert(string SETTING_KEY,string VALUES_KEY,string DES_KEY){
            var sp=new StoredProcedure("SETTING_UD_Insert",Provider);
				sp.Command.AddParameter("SETTING_KEY", SETTING_KEY,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("VALUES_KEY", VALUES_KEY,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("DES_KEY", DES_KEY,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SETTING_UD_SelectAll(){
            var sp=new StoredProcedure("SETTING_UD_SelectAll",Provider);
            return sp;
        }
        public StoredProcedure SETTING_UD_SelectRow(string SETTING_KEY){
            var sp=new StoredProcedure("SETTING_UD_SelectRow",Provider);
				sp.Command.AddParameter("SETTING_KEY", SETTING_KEY,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
        public StoredProcedure SETTING_UD_Update(string SETTING_KEY,string VALUES_KEY,string DES_KEY){
            var sp=new StoredProcedure("SETTING_UD_Update",Provider);
				sp.Command.AddParameter("SETTING_KEY", SETTING_KEY,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("VALUES_KEY", VALUES_KEY,DbType.String,ParameterDirection.Input);
					
				sp.Command.AddParameter("DES_KEY", DES_KEY,DbType.String,ParameterDirection.Input);
					
            return sp;
        }
	
	}
	
}
 