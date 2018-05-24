namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setDefaultBdayToNUll : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table Customers add constraint DF_Customers default null for Birthday");
        }
        
        public override void Down()
        {
        }
    }
}
