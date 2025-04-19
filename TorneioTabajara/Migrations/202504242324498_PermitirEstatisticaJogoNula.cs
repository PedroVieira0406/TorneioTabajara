namespace TorneioTabajara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermitirEstatisticaJogoNula : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Partida", "EstatisticaJogoId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Partida", "EstatisticaJogoId", c => c.Int(nullable: false));
        }
    }
}
