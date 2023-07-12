namespace NamoroApp.Models
{
    public class UsuarioApp
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public byte[] SenhaHas { get; set; }
        public byte[] ReSenha { get; set; }

    }
}
