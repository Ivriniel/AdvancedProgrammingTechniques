namespace MojaBiblioteczka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZMianaDlugosciPropercji3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rozdzial", "IdKsiazka", "dbo.Ksiazka");
            DropIndex("dbo.Rozdzial", new[] { "IdKsiazka" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Rozdzial", "IdKsiazka");
            AddForeignKey("dbo.Rozdzial", "IdKsiazka", "dbo.Ksiazka", "Id", cascadeDelete: true);
        }
    }
}
