using System.Text.Json.Serialization;

namespace UniversitasApp.Models
{
    public sealed class UserStaff
    {
        public int? stf_id { get; set; }
        public int? stf_u_id { get; set; }
        public int? stf_sc_id { get; set; }
        public int? stf_fks_id { get; set; }
        public int? stf_ps_id { get; set; }
        public int? stf_mk_id { get; set; }
        public string stf_fullname { get; set; }
        public string stf_nik { get; set; }
        public string stf_address { get; set; }
        public string stf_province { get; set; }
        public string stf_city { get; set; }
        public string stf_birthplace { get; set; }
        public string stf_birthdate { get; set; }
        public string stf_gender { get; set; }
        public string stf_religion { get; set; }
        public string stf_state { get; set; }
        public string stf_email { get; set; }
        public short? stf_stat { get; set; }
        public string stf_contact { get; set; }

        //Staff_category
        public int? sc_id { get; set; }
        public string sc_name { get; set; }
        public string sc_desc { get; set; }

        //users
        public int? u_id { get; set; }
        public int? u_ut_id { get; set; }
        public int? u_r_id { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }
    }
}