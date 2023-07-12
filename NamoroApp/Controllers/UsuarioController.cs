using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamoroApp.Data;
using NamoroApp.Models;
using System.Collections.Generic;

namespace NamoroApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioApp>>> GetUsuarios() 
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioApp>> GetUsuario(int id) 
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            
            return Ok(usuario);
        }
    }
}
