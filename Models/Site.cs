namespace UniversitasApp.Models
{
    public sealed class Site
    {
        public int? s_id { get; set; }
        public int? s_u_id { get; set; }
        public int? s_c_id { get; set; }
        public string s_fullname { get; set; }
        public string s_nik { get; set; }
        public string s_address { get; set; }
        public string s_province { get; set; }
        public string s_city { get; set; }
        public string s_birthplace { get; set; }
        public string s_birthdate { get; set; }
        public string s_gender { get; set; }
        public string s_religion { get; set; }
        public string s_state { get; set; }
        public string s_email { get; set; }
        public short? s_stat { get; set; }
        public string s_contact { get; set; }

        // Users Join
        public int? u_id { get; set; }
        public int? u_ut_id { get; set; }
        public int? u_r_id { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }
        public string u_login_time { get; set; }
        public string u_logout_time { get; set; }
        public short? u_login_status { get; set; }
    }
}