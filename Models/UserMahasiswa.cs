namespace UniversitasApp.Models
{
    public sealed class UserMahasiswa
    {
        public int? mhs_id { get; set; }
        public int? mhs_u_id { get; set; }
        public int? mhs_fks_id { get; set; }
        public int? mhs_ps_id { get; set; }
        public int? mhs_mk_id { get; set; }
        public string mhs_fullname { get; set; }
        public string mhs_nim { get; set; }
        public string mhs_kelas { get; set; }
        public string mhs_address { get; set; }
        public string mhs_province { get; set; }
        public string mhs_city { get; set; }
        public string mhs_birthplace { get; set; }
        public string mhs_birthdate { get; set; }
        public string mhs_gender { get; set; }
        public string mhs_religion { get; set; }
        public string mhs_state { get; set; }
        public string mhs_email { get; set; }
        public short? mhs_stat { get; set; }
        public string mhs_contact { get; set; }

        //Users
        public int? u_id { get; set; }
        public int? u_ut_id { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }

        //fakultas
        public string fks_name { get; set; }
    }
}