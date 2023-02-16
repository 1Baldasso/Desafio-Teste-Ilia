using Desafio_Teste_Ilia.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Teste_Ilia.Database
{
    public class APIContext : DbContext
    {

        private string DataSource = "LUCAS_BALDASSO";
        private string DatabaseName = "DbAPI";
        private string ConnectionString;

        public APIContext() => ConnectionString = $"server=.;data source={DataSource};initial catalog={DatabaseName};integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConnectionString, x => x.EnableRetryOnFailure());
        }

        public virtual DbSet<Registro> Registros { get;set; }
        public virtual DbSet<Alocacao> Alocacao { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Relatorio> Relatorios { get; set; }
    }
}
