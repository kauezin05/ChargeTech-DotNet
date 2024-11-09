using ChargeTechApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChargeTechApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<ConsumoEnergetico> ConsumosEnergeticos { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dispositivo>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(d => d.ID_USUARIO)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Dispositivo>()
                .HasOne<Ambiente>()
                .WithMany()
                .HasForeignKey(d => d.ID_AMBIENTE)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ConsumoEnergetico>()
                .HasOne<Dispositivo>()
                .WithMany()
                .HasForeignKey(c => c.ID_DISPOSITIVO)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
