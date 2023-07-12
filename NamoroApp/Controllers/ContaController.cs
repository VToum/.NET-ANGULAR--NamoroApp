using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NamoroApp.Data;
using NamoroApp.Dtos;
using NamoroApp.Models;
using System.Security.Cryptography;
using System.Text;

namespace NamoroApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly DataContext _context;

        public ContaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioApp>> Cadastro(CadastroDto cadastroDto)
        {
            if (await LoginExiste(cadastroDto.Login)) return BadRequest("Login Existe");

            using var hmac = new HMACSHA512();

            var usuario = new UsuarioApp
            {
                Login = cadastroDto.Login.ToLower(),
                SenhaHas = hmac.ComputeHash(Encoding.UTF8.GetBytes(cadastroDto.Senha)),
                ReSenha = hmac.Key
            };
            _context.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        private Task<bool> LoginExiste(string login)
        {
            return _context.Usuarios.AnyAsync(x => x.Login == login.ToLower());
        } 
    }
}
