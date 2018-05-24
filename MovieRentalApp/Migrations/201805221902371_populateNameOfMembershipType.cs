namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = Case " +
                                                        "when Id = 1 then 'Pay as You Go'" +
                                                        "when id = 2 then 'Monthly'" +
                                                        "when id = 3 then 'Quarterly'" +
                                                        "when id = 4 then 'Annual'" +
                                                        "End");
        }
        
        public override void Down()
        {
        }
    }
}
