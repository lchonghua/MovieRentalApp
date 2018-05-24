namespace MovieRentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateNameFieldInMembershipType : DbMigration
    {
        public override void Up()
        {
            //Sql("Update MembershipTypes Set Name = 'Pay as You Go' Where Id = 1 ");
            //Sql("Update MembershipTypes Set Name = 'Monthly' Where Id = 2 ");
            //Sql("Update MembershipTypes Set Name = 'Quarterly' Where Id = 3 ");
            //Sql("Update MembershipTypes Set Name = 'Annual' Where Id = 4 ");
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
