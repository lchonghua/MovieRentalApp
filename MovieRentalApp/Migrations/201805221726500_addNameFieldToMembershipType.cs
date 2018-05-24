namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameFieldToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Alter Table MembershipTypes Add Name varchar(255)");

        }
        
        public override void Down()
        {
        }
    }
}
