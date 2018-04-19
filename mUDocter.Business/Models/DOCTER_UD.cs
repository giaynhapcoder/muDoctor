using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the DOCTER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_UD
    {
        public int id {get; set; }
        
        public int user_id {get; set; }
        
        public string name {get; set; }
        
        public string dob {get; set; }
        
        public int? sex_id {get; set; }
        
        public string info_p {get; set; }
        
        public string hospital {get; set; }
        
        public int? year {get; set; }
        
        public int province_id {get; set; }
        
        public int? distrct_id {get; set; }
        
        public int? wards_id {get; set; }

        public string address { get; set; }
        
        public double longitude {get; set; }
        
        public double latitude {get; set; }
        
        public int? star {get; set; }
        
        public DateTime created {get; set; }
        
        public int status {get; set; }

        public string avartar { get; set; }
             

    } 
}