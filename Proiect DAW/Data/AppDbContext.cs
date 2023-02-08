using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Models;

namespace Proiect_DAW.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Producator> Producatori { get; set; }
        public DbSet<Vanzator> Vanzatori { get; set; }
        public DbSet<Produs_Vanzator> Produse_Vanzatori { get; set; }
        public DbSet<Locatie> Locatii { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Tabela asociativa Produs_Vanzator (Rezultata din M - M Produs - Vanzator)
            modelBuilder.Entity<Produs_Vanzator>().HasKey(pk => new {
                pk.ProdusId, 
                pk.VanzatorId
            });

            //Legătura dintre Produs_Vanzator cu Produs
            modelBuilder.Entity<Produs_Vanzator>()
                .HasOne<Produs>(p => p.Produs)
                .WithMany(pk => pk.Produs_Vanzator)
                .HasForeignKey(p => p.ProdusId);

            //Legătura dintre Produs_Vanzator cu Vanzator
            modelBuilder.Entity<Produs_Vanzator>()
                .HasOne<Vanzator>(v => v.Vanzator)
                .WithMany(pk => pk.Produs_Vanzator)
                .HasForeignKey(v => v.VanzatorId);

            //Legătura dintre Produs - Producator (1 - M)
            modelBuilder.Entity<Producator>()
                .HasMany(pr => pr.Produse)
                .WithOne(p => p.Producator);

            // Legătura dintre Locatie si Producator (1 - 1)
            modelBuilder.Entity<Producator>()
                .HasOne(l => l.Locatie)
                .WithOne(pr => pr.Producator)
                .HasForeignKey<Producator>(l => l.LocatieId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
