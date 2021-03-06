using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{
    public partial class Pengaduan : BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Tanggal { get; set; }
        public int IdJenisPengaduan { get; set; }
        public string? IdKecamatan { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Alamat { get; set; }
        public string? Keterangan { get; set; }
        public string? Status { get; set; }
        public int IdUser { get; set; }
    }
}
