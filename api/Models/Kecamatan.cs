using System;
using System.Collections.Generic;

namespace Ewadul.Api.Models
{
    public partial class Kecamatan
    {
        public string Id { get; set; } = null!;
        public string? RegencyId { get; set; }
        public string? Nama { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
    }
}
