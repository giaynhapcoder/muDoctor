namespace mUDocter.Business.Models    
{    
    /// <summary>
    /// A class which represents the DOCTER_IN_SER_UD table in the Main Database.
    /// </summary>
    public class DOCTER_IN_SER_UD
    {
         
        public int docter_id {get; set; }
        
        public int service_id {get; set; }

        public int price { get; set; }        

    } 
}
