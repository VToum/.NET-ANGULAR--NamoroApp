using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NamoroApp.Data;
using NamoroApp.Models;

namespace NamoroApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context) 
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "texto secreto";
        }

        [HttpGet("not-found")]
        public ActionResult<UsuarioApp> GetNotFound()
        {
            var thing = _context.Usuarios.Find(-1);

            if (thing == null) return NotFound();

            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServeError()
        {

                var thing = _context.Usuarios.Find(-1);

                var thingToReturn = thing.ToString();

                return thingToReturn;
        
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Não foi um bom pedido");
        }
    }
}
