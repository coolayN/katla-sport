namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        department_code = c.String(nullable: false, maxLength: 5),
                        department_name = c.String(nullable: false, maxLength: 60),
                        deleted = c.Boolean(nullable: false),
                        updated_utc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.departments", t => t.ParentId)
                .Index(t => t.ParentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.departments", "ParentId", "dbo.departments");
            DropIndex("dbo.departments", new[] { "ParentId" });
            DropTable("dbo.departments");
        }
    }
}
