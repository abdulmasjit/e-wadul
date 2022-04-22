using System;
using System.Collections.Generic;

namespace Ewadul.Api.DTO
{    
    public class JenisPengaduanDTO
    {
        public int Id { get; set; } 
        public string? Nama { get; set; } 
    }

    public class RequestJenisPengaduan
    {
        public string? Nama { get; set; }
    }
}
