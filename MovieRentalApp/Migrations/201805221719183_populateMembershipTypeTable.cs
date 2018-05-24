namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (SignUpFee, DurationInMonths, DiscountRate) values(0,0,0),(30, 1, 10),(90, 3, 15),(300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
