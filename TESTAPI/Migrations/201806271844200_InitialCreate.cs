namespace TESTAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        tbl_id = c.Int(nullable: false, identity: true),
                        id = c.String(),
                        user = c.String(),
                        fecha = c.String(),
                        personas = c.Int(nullable: false),
                        categoria = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.tbl_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Eventoes");
        }
    }
}
