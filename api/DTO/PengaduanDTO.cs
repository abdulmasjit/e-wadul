using System;
using System.Collections.Generic;

namespace Ewadul.Api.DTO
{    
    public class PengaduanDTO
    {
        public class PengaduanRequest{
            public string? Tanggal { get; set; }
            public int IdJenisPengaduan { get; set; }
            public string? IdKecamatan { get; set; }
            public string? Longitude { get; set; }
            public string? Latitude { get; set; }
            public string? Alamat { get; set; }
            public string? Keterangan { get; set; }
            public int IdUser { get; set; }
            public string? Status { get; set; }
        }

        public class PengaduanResponse{
            public int Id { get; set; }
            public DateTime? Tanggal { get; set; }
            public int IdJenisPengaduan { get; set; }
            public string? JenisPengaduan { get; set; }
            public string? IdKecamatan { get; set; }
            public string? NamaKecamatan { get; set; }
            public string? Longitude { get; set; }
            public string? Latitude { get; set; }
            public string? Alamat { get; set; }
            public string? Keterangan { get; set; }
            public int IdUser { get; set; }
            public string? NamaUser { get; set; }
            public string? Telepon { get; set; }
            public string? Nik { get; set; }
            public string? Status { get; set; }
            public string? StatusPengaduan { get; set; }
        }
    }
}
