using System.ComponentModel.DataAnnotations;

namespace NamoroApp.Dtos
{
    public class CadastroDto
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string? Senha { get; set; }

    }
}
