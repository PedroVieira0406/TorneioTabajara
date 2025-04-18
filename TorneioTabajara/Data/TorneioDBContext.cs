using System.Data.Entity;
using TorneioTabajara.Models;

namespace TorneioTabajara.Data
{
    public class TorneioContext : DbContext
    {
        public TorneioContext() : base("name=TorneioDBContext") { }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<EstatisticaJogo> EstatisticasJogos { get; set; }
        public DbSet<Gol> Gols { get; set; }
        public DbSet<Comissao> Comissoes { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Definir a relação de 1:1 entre Partida e EstatisticaJogo
            modelBuilder.Entity<Partida>()
                        .HasOptional(p => p.EstatisticaJogo)  // Parte "de um" (Partida)
                        .WithRequired(e => e.Partida);        // Parte "de um" (EstatisticaJogo)
        }
    }
}
