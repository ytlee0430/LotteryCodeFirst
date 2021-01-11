namespace Lottery.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbiglotterysequence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BigLotteryRecordSequences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        First = c.Int(nullable: false),
                        Second = c.Int(nullable: false),
                        Third = c.Int(nullable: false),
                        Fourth = c.Int(nullable: false),
                        Fifth = c.Int(nullable: false),
                        Sixth = c.Int(nullable: false),
                        Special = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BigLotteryRecordSequences");
        }
    }
}
