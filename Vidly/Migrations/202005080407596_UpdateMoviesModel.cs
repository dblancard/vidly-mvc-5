namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);


            
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);

            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Comedy'),(2,'Action'),(3,'Family'),(4,'Romance')");

            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock, DateAdded) VALUES ('Hangover',1,'2009-05-06',4,'2000-01-01')");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock, DateAdded) VALUES ('Die Hard',2,'2009-07-12',2,'2000-01-01')");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock, DateAdded) VALUES ('The Terminator',2,'1984-04-02',5,'2000-01-01')");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock, DateAdded) VALUES ('Toy Story',3,'2009-11-22',3,'2000-01-01')");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, NumberInStock, DateAdded) VALUES ('Titanic',4,'2009-12-20',1,'2000-01-01')");


        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
