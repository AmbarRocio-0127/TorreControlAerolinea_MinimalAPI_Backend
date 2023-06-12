using Microsoft.EntityFrameworkCore;
using BackendAerolinea.Models;

namespace BackendAerolinea
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer ("Server=DESKTOP-C52125S;Database=Aerolineadb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Avion> Avion => Set<Avion>();
        public DbSet<Aeropuerto> Aeropuerto => Set<Aeropuerto>();
        public DbSet<Pasajero> pasajeros => Set<Pasajero>();
    }
}
