using System;
using System.Collections.Generic;

namespace Ewadul.Api.DTO
{    
    public class RequestPengaduan
    {
        public string? Tanggal { get; set; }
        public int IdJenisPengaduan { get; set; }
        public string? IdKecamatan { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Alamat { get; set; }
        public string? Keterangan { get; set; }
        public int IdUser { get; set; }
    }
}
