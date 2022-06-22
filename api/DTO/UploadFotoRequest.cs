using System;
using System.ComponentModel.DataAnnotations;
namespace Ewadul.Api.DTO
{    
    public class UploadFotoRequest
    {
        [Required] 
        public int idPengaduan { get; set; }
        [Required] 
        public IFormFile? fileUpload { get; set; } 
    }
}
