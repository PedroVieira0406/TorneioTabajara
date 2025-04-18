namespace TorneioTabajara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reestruturando_Codigo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(nullable: false),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Cargo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Time",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        AnoFundacao = c.Int(nullable: false),
                        Estadio = c.String(),
                        CapacidadeEstadio = c.Int(nullable: false),
                        CorPrimaria = c.String(),
                        CorSecundaria = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jogador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Nacionalidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Posicao = c.Int(nullable: false),
                        Camisa = c.Int(nullable: false),
                        Altura = c.Double(nullable: false),
                        Peso = c.Double(nullable: false),
                        TimeId = c.Int(nullable: false),
                        PePreferido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.EstatisticaJogo",
                c => new
                    {
                        PartidaId = c.Int(nullable: false),
                        PlacarTime1 = c.Int(nullable: false),
                        PlacarTime2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartidaId)
                .ForeignKey("dbo.Partida", t => t.PartidaId)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.Gol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JogadorId = c.Int(nullable: false),
                        EstatisticaJogoId = c.Int(nullable: false),
                        Minuto = c.Int(nullable: false),
                        TipoGol = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstatisticaJogo", t => t.EstatisticaJogoId)
                .ForeignKey("dbo.Jogador", t => t.JogadorId, cascadeDelete: true)
                .Index(t => t.JogadorId)
                .Index(t => t.EstatisticaJogoId);
            
            CreateTable(
                "dbo.Partida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rodada = c.Int(nullable: false),
                        Time1Id = c.Int(nullable: false),
                        Time2Id = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        EstatisticaJogoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.Time1Id)
                .ForeignKey("dbo.Time", t => t.Time2Id)
                .Index(t => t.Time1Id)
                .Index(t => t.Time2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partida", "Time2Id", "dbo.Time");
            DropForeignKey("dbo.Partida", "Time1Id", "dbo.Time");
            DropForeignKey("dbo.EstatisticaJogo", "PartidaId", "dbo.Partida");
            DropForeignKey("dbo.Gol", "JogadorId", "dbo.Jogador");
            DropForeignKey("dbo.Gol", "EstatisticaJogoId", "dbo.EstatisticaJogo");
            DropForeignKey("dbo.Jogador", "TimeId", "dbo.Time");
            DropForeignKey("dbo.Comissao", "TimeId", "dbo.Time");
            DropIndex("dbo.Partida", new[] { "Time2Id" });
            DropIndex("dbo.Partida", new[] { "Time1Id" });
            DropIndex("dbo.Gol", new[] { "EstatisticaJogoId" });
            DropIndex("dbo.Gol", new[] { "JogadorId" });
            DropIndex("dbo.EstatisticaJogo", new[] { "PartidaId" });
            DropIndex("dbo.Jogador", new[] { "TimeId" });
            DropIndex("dbo.Comissao", new[] { "TimeId" });
            DropTable("dbo.Partida");
            DropTable("dbo.Gol");
            DropTable("dbo.EstatisticaJogo");
            DropTable("dbo.Jogador");
            DropTable("dbo.Time");
            DropTable("dbo.Comissao");
        }
    }
}
