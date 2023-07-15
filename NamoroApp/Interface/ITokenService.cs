using NamoroApp.Models;

namespace NamoroApp.Interface
{
    public interface ITokenService
    {
        string CriarToken(UsuarioApp usuarioApp);
    }
}
