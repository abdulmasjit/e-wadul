using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
using Ewadul.Api.Services;
using Ewadul.Api.Helpers;
namespace Ewadul.Api.Controllers
{
    // Setting nama route
    [Route("api/v1/pengaduan")]
    [ApiController]
    public class PengaduanController : ControllerBase
    {
        private readonly DataContext _context;
        private IPengaduanService _pengaduanService;
        private readonly ILogger<PengaduanController> _logger;

        public PengaduanController(DataContext context, ILogger<PengaduanController> logger, IPengaduanService pengaduanService)
        {
            _context = context;
            _pengaduanService = pengaduanService;
            _logger = logger;
        }

        // GET: api/v1/pengaduan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pengaduan>>> GetAll()
        {
            var response = _pengaduanService.GetAll();
            if (response == null)
                return BadRequest(new { message = "Data tidak ditemukan" });

            return Ok(response);
            // return await _context.Pengaduans.ToListAsync();
        }

        // GET: api/v1/pengaduan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pengaduan>> GetById(int id)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);

            if (pengaduan == null)
            {
                return NotFound();
            }

            return pengaduan;
        }

        // POST: api/v1/pengaduan
        [HttpPost]
        public async Task<ActionResult<Pengaduan>> CreatePengaduan(PengaduanDTO.PengaduanRequest req)
        {
            DateTime dt = Convert.ToDateTime(req.Tanggal);
            string  s2 = dt.ToString("yyyy-MM-dd");
            DateTime tglPengaduan = Convert.ToDateTime(s2);

            var pengaduan = new Pengaduan(){
                Tanggal = tglPengaduan,
                IdJenisPengaduan = req.IdJenisPengaduan,
                IdKecamatan = req.IdKecamatan,
                Longitude = req.Longitude,
                Latitude = req.Latitude,
                Alamat = req.Alamat,
                Keterangan = req.Keterangan,
                IdUser = req.IdUser,
                Status = "1" // PROSES
            };

            _context.Pengaduans.Add(pengaduan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = pengaduan.Id }, pengaduan);
        }

        // PUT: api/v1/pengaduan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePengaduan(int id, PengaduanDTO.PengaduanRequest req)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);
            if (pengaduan == null)
            {
                return NotFound();
            }
            
            // Binding data
            DateTime dt = Convert.ToDateTime(req.Tanggal);
            string  s2 = dt.ToString("yyyy-MM-dd");
            DateTime tglPengaduan = Convert.ToDateTime(s2);

            pengaduan.Tanggal = tglPengaduan;
            pengaduan.IdJenisPengaduan = req.IdJenisPengaduan;
            pengaduan.IdKecamatan = req.IdKecamatan;
            pengaduan.Longitude = req.Longitude;
            pengaduan.Latitude = req.Latitude;
            pengaduan.Alamat = req.Alamat;
            pengaduan.Keterangan = req.Keterangan;
            pengaduan.Status = req.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PengaduanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetById", new { id = id }, pengaduan);
        }

        // DELETE: api/v1/pengaduan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePengaduan(int id)
        {
            var pengaduan = await _context.Pengaduans.FindAsync(id);
            if (pengaduan == null)
            {
                return NotFound();
            }

            _context.Pengaduans.Remove(pengaduan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PengaduanExists(int id)
        {
            return _context.Pengaduans.Any(e => e.Id == id);
        }

        /**
        * Function Upload Foto Pengaduan
        * 
        */

        [HttpPost("upload-foto")]
        public async Task<ActionResult> UploadImage([FromForm] UploadFotoRequest req)
        {
            _logger.LogInformation("id pengaduan : " + req.idPengaduan);
            _logger.LogInformation("file uploaded : " + req.fileUpload.FileName);
            _logger.LogInformation("file type : " + Path.GetExtension(req.fileUpload.FileName));

            // Function Upload File
            string fileType = Path.GetExtension(req.fileUpload.FileName);
            string fileName = AppHelper.generateKode("foto_pengaduan_") + fileType;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/pengaduan", fileName);
            var stream = new FileStream(path, FileMode.Create);
            req.fileUpload.CopyToAsync(stream);
            string pathUrl = "files/pengaduan/" + fileName;

            // Save to DB
            var pengaduanFoto = new PengaduanFoto(){
                IdPengaduan = req.idPengaduan,
                Foto = pathUrl,
            };

            _context.PengaduanFotos.Add(pengaduanFoto);
            await _context.SaveChangesAsync();

            var response = new {
                success = true,
                message = "Upload foto berhasil",
            };   
            return Ok(response);
        }
    }
}
