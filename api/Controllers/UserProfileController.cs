#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
using Ewadul.Api.Helpers;

namespace Ewadul.Api.Controllers
{
    //setting nama route
    [Route("api/v1/userProfile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly DataContext _context;

        public UserProfileController(DataContext context)
        {
            _context = context;
        }

        // PUT: api/v1/ProfileUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfileUser(int id, RequestUserProfile req)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Binding data
            string md5StringPassword = (req.Password != "") ? AppHelper.GetMd5Hash(req.Password) : user.Password;
            user.Nama = req.Nama;
            user.Username = req.Username;
            user.Email = req.Email;
            user.Password = md5StringPassword;
            user.Nik = req.Nik;
            user.Telepon = req.Telepon;
            user.Alamat = req.Alamat;
            user.Status = 1; //aktif 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
