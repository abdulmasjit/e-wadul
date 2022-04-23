using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{
    public partial class Pengaduan : BaseEntity
    {
        public long Id { get; set; }
        public DateOnly Tanggal { get; set; }
        public int IdJenisPengaduan { get; set; }
        public string IdKecamatan { get; set; } = null!;
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string Alamat { get; set; } = null!;
        public string Keterangan { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int IdUser { get; set; }
    }
}
