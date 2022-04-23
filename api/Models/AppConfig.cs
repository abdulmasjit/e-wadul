using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{
    public partial class AppConfig
    {
        public string Id { get; set; } = null!;
        public string? NamaSistem { get; set; }
        public string? Tagline { get; set; }
        public string? Instansi { get; set; }
        public string? Status { get; set; }
        public string? Favicon { get; set; }
        public string? Logo { get; set; }
        public string? ChildLogo { get; set; }
        public string? EmailInstansi { get; set; }
        public string? PassInstansi { get; set; }
        public string? UrlRoot { get; set; }
        public string? Jalan { get; set; }
        public string? Kelurahan { get; set; }
        public string? Kecamatan { get; set; }
        public string? Kabupaten { get; set; }
        public string? Provinsi { get; set; }
        public string? KodePos { get; set; }
        public string? Telp { get; set; }
        public string? Fax { get; set; }
    }
}
