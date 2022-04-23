using System;
using System.Collections.Generic;
namespace Ewadul.Api.Models
{
    public partial class JenisPengaduan : BaseEntity
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public sbyte? Status { get; set; }
    }
}
