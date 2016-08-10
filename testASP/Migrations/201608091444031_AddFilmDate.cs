namespace testASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilmDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Film", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Film", "Date");
        }
    }
}
