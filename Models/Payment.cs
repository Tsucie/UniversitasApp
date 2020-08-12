namespace UniversitasApp.Models
{
    public sealed class Payment
    {
        public int pi_id { get; set; }
        public int pi_mhs_id { get; set; }
        public string pi_code { get; set; }
        public string pi_name { get; set; }
        public int pi_value { get; set; }
        public short pi_stat { get; set; }
        public string pi_date { get; set; }
        public string pi_channel { get; set; }
        public string pi_desc { get; set; }
    }
}