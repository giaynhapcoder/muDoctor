using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the USER_UD table in the Main Database.
    /// </summary>
    public class USER_UD
    {
               
        public int id {get; set; }
        
        public string username {get; set; }
        
        public string password {get; set; }
        
        public string full_name {get; set; }
        
        public string address {get; set; }
        
        public string phone {get; set; }
        
        public string email {get; set; }

        public string avartar { get; set; }

        public int user_type {get; set; }
        
        public int? status {get; set; }
        
        public DateTime created {get; set; }

        public string facebook_id { get; set; }

        public string gooogle_id { get; set; }
    } 
}