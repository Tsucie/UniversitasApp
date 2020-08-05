namespace UniversitasApp.Models
{
    public sealed class ProgramStudi
    {
        public int? ps_id { get; set; }
        public int? ps_fks_id { get; set; }
        public string ps_name { get; set; }
        public string ps_desc { get; set; }
    }
}