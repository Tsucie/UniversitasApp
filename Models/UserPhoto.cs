using System.Text.Json.Serialization;

namespace UniversitasApp.Models
{
    public sealed class UserPhoto
    {
        public int? up_id { get; set; }

        public int? up_u_id { get; set; }

        public byte[] up_photo { get; set; }

        public string up_filename { get; set; }
        
        [JsonIgnore]
        public short up_rec_status { get; set; }
    }
}