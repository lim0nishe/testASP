namespace testASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Patronymic = c.String(),
                        Sex = c.Int(),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Budget = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FilmActor",
                c => new
                    {
                        Film_ID = c.Int(nullable: false),
                        Actor_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_ID, t.Actor_ID })
                .ForeignKey("dbo.Film", t => t.Film_ID, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.Actor_ID, cascadeDelete: true)
                .Index(t => t.Film_ID)
                .Index(t => t.Actor_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmActor", "Actor_ID", "dbo.Actor");
            DropForeignKey("dbo.FilmActor", "Film_ID", "dbo.Film");
            DropIndex("dbo.FilmActor", new[] { "Actor_ID" });
            DropIndex("dbo.FilmActor", new[] { "Film_ID" });
            DropTable("dbo.FilmActor");
            DropTable("dbo.Film");
            DropTable("dbo.Actor");
        }
    }
}
