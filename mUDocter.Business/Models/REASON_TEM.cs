using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the REASON_TEM table in the Main Database.
    /// </summary>
    public class REASON_TEM
    {
               

        
        public int id {get; set; }
        
        public string Name {get; set; }
        
        public int Status {get; set; }
        
        public DateTime Created {get; set; }
             

    } 
}