namespace TorneioTabajara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizandoPartida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comissaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(nullable: false),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Times",
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
                "dbo.Jogadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Nacionalidade = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Camisa = c.Int(nullable: false),
                        Altura = c.Double(nullable: false),
                        Peso = c.Double(nullable: false),
                        TimeId = c.Int(nullable: false),
                        PePreferido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.EstatisticaJogoes",
                c => new
                    {
                        PartidaId = c.Int(nullable: false),
                        PlacarTime1 = c.Int(nullable: false),
                        PlacarTime2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartidaId)
                .ForeignKey("dbo.Partidas", t => t.PartidaId)
                .Index(t => t.PartidaId);
            
            CreateTable(
                "dbo.Gols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JogadorId = c.Int(nullable: false),
                        EstatisticaJogoId = c.Int(nullable: false),
                        Minuto = c.Int(nullable: false),
                        TipoGol = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstatisticaJogoes", t => t.EstatisticaJogoId, cascadeDelete: true)
                .ForeignKey("dbo.Jogadors", t => t.JogadorId, cascadeDelete: true)
                .Index(t => t.JogadorId)
                .Index(t => t.EstatisticaJogoId);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rodada = c.Int(nullable: false),
                        Time1Id = c.Int(nullable: false),
                        Time2Id = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        EstatisticaJogoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Times", t => t.Time1Id, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.Time2Id, cascadeDelete: true)
                .Index(t => t.Time1Id)
                .Index(t => t.Time2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partidas", "Time2Id", "dbo.Times");
            DropForeignKey("dbo.Partidas", "Time1Id", "dbo.Times");
            DropForeignKey("dbo.EstatisticaJogoes", "PartidaId", "dbo.Partidas");
            DropForeignKey("dbo.Gols", "JogadorId", "dbo.Jogadors");
            DropForeignKey("dbo.Gols", "EstatisticaJogoId", "dbo.EstatisticaJogoes");
            DropForeignKey("dbo.Jogadors", "TimeId", "dbo.Times");
            DropForeignKey("dbo.Comissaos", "TimeId", "dbo.Times");
            DropIndex("dbo.Partidas", new[] { "Time2Id" });
            DropIndex("dbo.Partidas", new[] { "Time1Id" });
            DropIndex("dbo.Gols", new[] { "EstatisticaJogoId" });
            DropIndex("dbo.Gols", new[] { "JogadorId" });
            DropIndex("dbo.EstatisticaJogoes", new[] { "PartidaId" });
            DropIndex("dbo.Jogadors", new[] { "TimeId" });
            DropIndex("dbo.Comissaos", new[] { "TimeId" });
            DropTable("dbo.Partidas");
            DropTable("dbo.Gols");
            DropTable("dbo.EstatisticaJogoes");
            DropTable("dbo.Jogadors");
            DropTable("dbo.Times");
            DropTable("dbo.Comissaos");
        }
    }
}
