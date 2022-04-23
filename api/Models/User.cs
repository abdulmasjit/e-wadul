using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ewadul.Api.Models
{
    public partial class User : BaseEntity
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Nik { get; set; }
        public string? Telepon { get; set; }
        public string? Alamat { get; set; }
        public string? Status { get; set; }
        public string? IdRole { get; set; }
    
        [JsonIgnore]
        public string? Password { get; set; }
    }
}
