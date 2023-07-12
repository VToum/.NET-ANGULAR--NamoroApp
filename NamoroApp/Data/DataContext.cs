using Microsoft.EntityFrameworkCore;
using NamoroApp.Models;

namespace NamoroApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioApp> Usuarios { get; set; }
    }
}
