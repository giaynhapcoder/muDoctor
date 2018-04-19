using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the WARDS_UD table in the Main Database.
    /// </summary>
    public class WARDS_UD
    {
        public int id {get; set; }
        
        public int dictrct_id {get; set; }
        
        public string name {get; set; }
        
        public int orders {get; set; }
        
        public DateTime created {get; set; }
        
        public int status {get; set; }
             

    } 
}