namespace EF08_Database_Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", 
                c => c.String(
                    nullable: false,
                    maxLength: 250,
                    fixedLength: false,
                    unicode: true));
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Address");
        }
    }
}
