using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class SyscscContext : DbContext
    {
        public SyscscContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cultivo> Cultivos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Agroclimatica> Agroclimaticas { get; set; }
        public DbSet<DatosFamilia> DatosFamilias { get; set; }
        public DbSet<InsumoExterno> InsumoExternos { get; set; }
        public DbSet<InsumoInterno> InsumoInternos { get; set; } 
        public DbSet<UsoSuelo> UsoSuelos { get; set; }  
        public DbSet<ManejoCultivo> ManejoCultivos { get; set; }  
        
    }
}