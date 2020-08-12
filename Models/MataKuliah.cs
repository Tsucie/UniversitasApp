namespace UniversitasApp.Models
{
    public sealed class MataKuliah
    {
        public int mk_id { get; set; }
        public int mk_ps_id { get; set; }
        public int mk_sm_id { get; set; }
        public int mk_sks { get; set; }
        public int mk_mutu { get; set; }
        public string mk_code { get; set; }
        public string mk_name { get; set; }
        public string mk_desc { get; set; }
    }
}