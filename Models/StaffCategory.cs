using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversitasApp.Models
{
    public sealed class StaffCategory
    {
        public int? sc_id { get; set; }
        public string sc_name { get; set; }
        public string sc_desc { get; set; }
    }
}