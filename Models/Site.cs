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

        // user_photo
        public string up_filename { get; set; }
        public byte[] up_photo { get; set; }

        // Role
        public string r_desc { get; set; }
    }
}