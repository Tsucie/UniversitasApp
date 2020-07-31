using System.Text.Json.Serialization;

namespace UniversitasApp.Models
{
    public sealed class RolePreviledge
    {
        public int? rp_id { get; set; }
        public int? rp_r_id { get; set; }
        public short rp_view { get; set; }
        public short rp_add { get; set; }
        public short rp_edit { get; set; }
        public short rp_delete { get; set; }
        [JsonIgnore]
        public short? rp_rec_status { get; set; }

        [JsonIgnore]
        public string rp_rec_creator { get; set; }

        [JsonIgnore]
        public string rp_rec_created { get; set; }

        [JsonIgnore]
        public string rp_rec_updator { get; set; }

        [JsonIgnore]
        public string rp_rec_updated { get; set; }

        [JsonIgnore]
        public string rp_rec_deletor { get; set; }

        [JsonIgnore]
        public string rp_rec_deleted { get; set; }

        // Role
        public string r_name { get; set; }
        public string r_desc { get; set; }
    }
}