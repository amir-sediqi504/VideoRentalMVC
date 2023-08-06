namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataToMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpfee, DurationInMonths, DiscountRate) VALUES (5 , 1, 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
