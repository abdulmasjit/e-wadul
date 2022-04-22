using System;
using System.Collections.Generic;

// Inheritence CreatedAt and UpdatedAt
namespace Ewadul.Api.Models
{    
    public abstract class BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}