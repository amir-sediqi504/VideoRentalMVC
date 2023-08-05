namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatecustomers : DbMigration
    {
        public override void Up()
        {
         Sql("INSERT INTO Customers ( Name, IsSubscribedToNewsLetter, MembershipTypeId) VALUES ( 'John Doe', 1, 2)");
         Sql("INSERT INTO Customers ( Name, IsSubscribedToNewsLetter, MembershipTypeId) VALUES ( 'mary john', 1, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
