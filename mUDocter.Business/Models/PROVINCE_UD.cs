using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the PROVINCE_UD table in the Main Database.
    /// </summary>
    public class PROVINCE_UD
    {
        public int id {get; set; }
        
        public string name {get; set; }
        
        public int orders {get; set; }
        
        public DateTime created {get; set; }
        
        public int status {get; set; }
             

    } 
}