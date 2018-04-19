namespace mUDocter.Business.Models.API
{
    public class BOOKING_INFO
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        public string patient_phone { get; set; }
        public int docter_id { get; set; }
        public string docter_name { get; set; }
        public string docter_phone { get; set; }
        public string comment { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public int status { get; set; }
        public int tam_date { get; set; }
        public int vs_date { get; set; }
        public double longitude { get; set; }

        public double latitude { get; set; }

        public double rate { get; set; }

        public string date_time { get; set; }
    }
}
