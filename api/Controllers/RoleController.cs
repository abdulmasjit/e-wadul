
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ewadul.Api.Data;
using Ewadul.Api.Models;
using Ewadul.Api.DTO;
using Ewadul.Api.Helpers;
using System;
using System.Collections.Generic;


namespace Ewadul.Api.Controllers
{
    // Setting nama route
    [Route("api/v1/role")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        // GET: api/v1/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
