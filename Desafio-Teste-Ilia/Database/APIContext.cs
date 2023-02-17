using Desafio_Teste_Ilia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio_Teste_Ilia.Database
{
    public class APIContext : DbContext
    {

        private string DataSource = "(localdb)\\MSSQLLocalDB";
        private string DatabaseName = "DbAPI";
        private string ConnectionString;

        public APIContext() => ConnectionString = $"server=.;data source={DataSource};initial catalog={DatabaseName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true";


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString, x => x.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relatorio>()
                .Property(x => x.HorasDevidas)
                .HasConversion(new TimeSpanToStringConverter());
            modelBuilder.Entity<Relatorio>()
                .Property(x => x.HorasExcedentes)
                .HasConversion(new TimeSpanToStringConverter());
            modelBuilder.Entity<Relatorio>()
                .Property(x => x.HorasTrabalhadas)
                .HasConversion(new TimeSpanToStringConverter());
            modelBuilder.Entity<Alocacao>()
                .Property(x=>x.Tempo)
                .HasConversion(new TimeSpanToStringConverter());
        }
        
        public virtual DbSet<Registro> Registros { get;set; }
        public virtual DbSet<Alocacao> Alocacao { get; set; }
        public virtual DbSet<Relatorio> Relatorios { get; set; }
        public virtual DbSet<Momento> Momentos { get; set; }
    }
}
