using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{    
    public class JenisPengaduan : BaseEntity
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public int? Status { get; set; }
    }
}
