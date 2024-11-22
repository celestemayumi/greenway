using Microsoft.EntityFrameworkCore;
using greenway2.Models;

namespace greenway2.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para as entidades
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeando as tabelas no banco de dados
            modelBuilder.Entity<Veiculo>().ToTable("GS_VEICULO");
            modelBuilder.Entity<Cadastro>().ToTable("GS_CADASTRO");
            modelBuilder.Entity<Login>().ToTable("GS_LOGIN");
            modelBuilder.Entity<Historico>().ToTable("GS_HISTORICO");

            modelBuilder.Entity<Cadastro>()
                .HasOne(c => c.Login)
                .WithOne(l => l.Cadastro) 
                .HasForeignKey<Cadastro>(c => c.IdLogin) 
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<Login>()
                .HasOne(l => l.Cadastro) 
                .WithOne(c => c.Login) 
                .HasForeignKey<Login>(l => l.Id)  
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Historico>()
                .HasOne(h => h.Cadastro)
                .WithMany() 
                .HasForeignKey(h => h.IdCadastro)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Historico>()
                .HasOne(h => h.Veiculo)
                .WithMany() 
                .HasForeignKey(h => h.IdVeiculo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
