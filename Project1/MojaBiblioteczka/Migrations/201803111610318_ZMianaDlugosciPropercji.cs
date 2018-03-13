namespace MojaBiblioteczka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZMianaDlugosciPropercji : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ksiazka", "Tytul", c => c.String(nullable: false));
            AlterColumn("dbo.Ksiazka", "ImieAutora", c => c.String(nullable: false));
            AlterColumn("dbo.Ksiazka", "NazwiskoAutora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ksiazka", "NazwiskoAutora", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Ksiazka", "ImieAutora", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Ksiazka", "Tytul", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
