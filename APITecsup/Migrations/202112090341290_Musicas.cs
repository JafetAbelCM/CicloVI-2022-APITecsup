namespace APITecsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Musicas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musicas",
                c => new
                    {
                        MusicID = c.Int(nullable: false, identity: true),
                        MusicName = c.String(),
                        MusicAutor = c.String(),
                    })
                .PrimaryKey(t => t.MusicID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musicas");
        }
    }
}
