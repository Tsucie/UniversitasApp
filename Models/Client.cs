using System.Text.Json.Serialization;

namespace UniversitasApp.Models
{
    public sealed class Client
    {
        public int? c_id { get; set; }
        public int? c_u_id { get; set; }
        public string c_code { get; set; }
        public string c_name { get; set; }
        public string c_remark { get; set; }

        //ClientUsers
        public int? u_id { get; set; }
        public int? u_ut_id { get; set; }
        public int? u_r_id { get; set; }
        public string u_username { get; set; }
        public string u_password { get; set; }
        public string u_login_time { get; set; }
        public string u_logout_time { get; set; }
        public short? u_login_status { get; set; }

        [JsonIgnore]
        public short? u_rec_status { get; set; }

        [JsonIgnore]
        public string u_rec_creator { get; set; }

        [JsonIgnore]
        public string u_rec_created { get; set; }

        [JsonIgnore]
        public string u_rec_updator { get; set; }

        [JsonIgnore]
        public string u_rec_updated { get; set; }

        [JsonIgnore]
        public string u_rec_deletor { get; set; }

        [JsonIgnore]
        public string u_rec_deleted { get; set; }
    }
}