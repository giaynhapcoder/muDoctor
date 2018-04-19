using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the SERVICE_UD table in the Main Database.
    /// </summary>
    public class SERVICE_UD
    {
        
        public int id {get; set; }
        
        public string name {get; set; }
        
        public string dec {get; set; }
        
        public int orders {get; set; }
        
        public DateTime created {get; set; }
        
        public int status {get; set; }
             

    } 
}
