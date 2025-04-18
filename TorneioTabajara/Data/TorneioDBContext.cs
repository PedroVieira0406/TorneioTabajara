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
        public DbSet<Comissao> Comissaos { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Nome das tabelas fixo para evitar erros com pluralização
            modelBuilder.Entity<Partida>().ToTable("Partida");
            modelBuilder.Entity<EstatisticaJogo>().ToTable("EstatisticaJogo");
            modelBuilder.Entity<Gol>().ToTable("Gol");
            modelBuilder.Entity<Comissao>().ToTable("Comissao");
            modelBuilder.Entity<Time>().ToTable("Time");
            modelBuilder.Entity<Jogador>().ToTable("Jogador");

            // Relação 1:1 entre Partida e EstatisticaJogo
            modelBuilder.Entity<Partida>()
                        .HasOptional(p => p.EstatisticaJogo)
                        .WithRequired(e => e.Partida);

            // Relações Partida ↔ Time (sem cascade delete)
            modelBuilder.Entity<Partida>()
                        .HasRequired(p => p.Time1)
                        .WithMany()
                        .HasForeignKey(p => p.Time1Id)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partida>()
                        .HasRequired(p => p.Time2)
                        .WithMany()
                        .HasForeignKey(p => p.Time2Id)
                        .WillCascadeOnDelete(false);

            // Relação Gol ↔ EstatisticaJogo (sem cascade delete)
            modelBuilder.Entity<Gol>()
                        .HasRequired(g => g.EstatisticaJogo)
                        .WithMany(e => e.Gols)
                        .HasForeignKey(g => g.EstatisticaJogoId)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
