using System;

namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the BOOKING_UD table in the Main Database.
    /// </summary>
    public class BOOKING_UD
    {
        
        public int id {get; set; }
        
        public int? patient_id {get; set; }
        
        public int? docter_id {get; set; }
        
        public DateTime? time_in {get; set; }
        
        public double? longitude {get; set; }
        
        public double? latitude {get; set; }
        
        public string comment {get; set; }
        
        public string created {get; set; }
        
        public int status {get; set; }

        public string updated { get; set; }

        public int tam_date { get; set; }

        public int vs_date { get; set; }

        public double rate { get; set; }

        public string date_time { get; set; }
             

    } 
}