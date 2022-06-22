using System;
using System.Collections.Generic;
namespace Ewadul.Api.Models
{
    public partial class PengaduanFoto
    {
        public int Id { get; set; }
        public int IdPengaduan { get; set; }
        public string? Foto { get; set; }
    }
}
