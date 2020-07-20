using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitasApp.Models
{
    public sealed class UserMahasiswa
    {
        public int? mhs_id { get; set; }
        public int? mhs_u_id { get; set; }
        public int? mhs_fks_id { get; set; }
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
        public int? u_r_id { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }
        public string u_login_time { get; set; }
        public string u_logout_time { get; set; }
        public short? u_login_status { get; set; }

        [JsonIgnore]
        public string u_rec_creator { get; set; }

        [JsonIgnore]
        public string u_rec_created { get; set; }
    }
}