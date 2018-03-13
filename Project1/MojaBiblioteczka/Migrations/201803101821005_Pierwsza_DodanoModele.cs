namespace MojaBiblioteczka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pierwsza_DodanoModele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ksiazka",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false, maxLength: 50),
                        ImieAutora = c.String(nullable: false, maxLength: 50),
                        NazwiskoAutora = c.String(nullable: false, maxLength: 5),
                        Ocena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rozdzial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdKsiazka = c.Int(nullable: false),
                        Streszczenie = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ksiazka", t => t.IdKsiazka, cascadeDelete: true)
                .Index(t => t.IdKsiazka);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rozdzial", "IdKsiazka", "dbo.Ksiazka");
            DropIndex("dbo.Rozdzial", new[] { "IdKsiazka" });
            DropTable("dbo.Rozdzial");
            DropTable("dbo.Ksiazka");
        }
    }
}
