using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamoroApp.Data;
using NamoroApp.Dtos;
using NamoroApp.Interface;
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
        private readonly ITokenService _tokenService;

        public ContaController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioDto>> Cadastro(CadastroDto cadastroDto) 
        {
            if (await LoginExiste(cadastroDto.Login)) return BadRequest("Login já Existe");

            using var hmac = new HMACSHA512();

            var usuario = new UsuarioApp
            {
                Login = cadastroDto.Login,
                SenhaHas = hmac.ComputeHash(Encoding.UTF8.GetBytes(cadastroDto.Senha)),
                ReSenha = hmac.Key
            };
            _context.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDto
            {
                Usuariologin = usuario.Login,
                Token = _tokenService.CriarToken(usuario)
            };

        }


        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto) 
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == loginDto.Login);

            if (usuario == null) return Unauthorized("Usuario Invalido");

            var hmac = new HMACSHA512(usuario.ReSenha);

            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Senha));

            for (int i = 0; i < computerHash.Length; i++)
            {
                if (computerHash[i] != usuario.SenhaHas[i]) return Unauthorized("Usuario Invalido");
            }

            return new UsuarioDto
            {
                Usuariologin = usuario.Login,
                Token = _tokenService.CriarToken(usuario)
            };

        }

        private Task<bool> LoginExiste(string login) 
        {
            return _context.Usuarios.AnyAsync(x => x.Login == login);
        }
    }
}
