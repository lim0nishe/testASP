namespace testASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceDateByGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Film", "Genre", c => c.Int(nullable: false));
            DropColumn("dbo.Film", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Film", "Date", c => c.DateTime());
            DropColumn("dbo.Film", "Genre");
        }
    }
}
