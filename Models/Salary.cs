namespace UniversitasApp.Models
{
    public sealed class Salary
    {
        public int sal_id { get; set; }
        public int? sal_stf_id { get; set; }
        public int? sal_s_id { get; set; }
        public string sal_code { get; set; }
        public int sal_value { get; set; }
        public string sal_date { get; set; }
        public string sal_channel { get; set; }
        public string sal_desc { get; set; }
    }
}