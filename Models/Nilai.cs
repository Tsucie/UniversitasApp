namespace UniversitasApp.Models
{
    public sealed class Nilai
    {
        public int n_id { get; set; }
        public int n_mk_id { get; set; }
        public int n_nc_id { get; set; }
        public int n_ips_id { get; set; }
        public int n_ipk_id { get; set; }
        public decimal n_value { get; set; }
        public string n_name { get; set; }
        public string n_desc { get; set; }

        // nilai_category
        public int nc_id { get; set; }
        public string nc_name { get; set; }
        public string nc_desc { get; set; }

        // ip_semester
        public int ips_id { get; set; }
        public int ips_s_id { get; set; }
        public decimal ips_value { get; set; }
        public string ips_desc { get; set; }

        // ip_komulatif
        public int ipk_id { get; set; }
        public decimal ipk_value { get; set; }
        public string ipk_desc { get; set; }
    }
}