namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Name) values ('Action'), ('Drama'),('Comedy'),('SciFi'),('Horror'), ('Advanture')");
        }
        
        public override void Down()
        {
        }
    }
}
