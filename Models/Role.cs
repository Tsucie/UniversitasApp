using System.Text.Json.Serialization;

namespace UniversitasApp.Models
{
    public sealed class Role
    {
        public int? r_id { get; set; }
        public int? r_rt_id { get; set; }
        public int? r_c_id { get; set; }
        public int? r_s_id { get; set; }
        public string r_name { get; set; }
        public string r_desc { get; set; }
        [JsonIgnore]
        public short? r_rec_status { get; set; }

        [JsonIgnore]
        public string r_rec_creator { get; set; }

        [JsonIgnore]
        public string r_rec_created { get; set; }

        [JsonIgnore]
        public string r_rec_updator { get; set; }

        [JsonIgnore]
        public string r_rec_updated { get; set; }

        [JsonIgnore]
        public string r_rec_deletor { get; set; }

        [JsonIgnore]
        public string r_rec_deleted { get; set; }

        //role_type
        public int rt_id { get; set; }
        public string rt_name { get; set; }
        public string rt_desc { get; set; }

        //users
        public string u_username { get; set; }
    }
}