using System;
using System.Collections.Generic;

namespace Ewadul.Api.DTO
{
    public class RequestUserProfile
    {
        public string? Nama { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Nik { get; set; }
        public string? Telepon { get; set; }
        public string? Alamat { get; set; }
    }
}
