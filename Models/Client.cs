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
    }
}