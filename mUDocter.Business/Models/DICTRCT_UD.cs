using System;

namespace mUDocter.Business    
{    
    /// <summary>
    /// A class which represents the DICTRCT_UD table in the Main Database.
    /// </summary>
    public class DICTRCT_UD
    {
               

        
        public int id {get; set; }
        
        public int province_id {get; set; }
        
        public string name {get; set; }
        
        public int orders {get; set; }
        
        public DateTime created {get; set; }
        
        public int status {get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }
             

    } 
}