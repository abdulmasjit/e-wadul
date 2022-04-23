using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{
    public partial class User : BaseEntity
    {
        public int Id { get; set; }
        public string Nama { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nik { get; set; } = null!;
        public string Telepon { get; set; } = null!;
        public string Alamat { get; set; } = null!;
        public sbyte Status { get; set; }
        public string IdRole { get; set; } = null!;
    }
}
