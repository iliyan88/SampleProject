namespace SimpleEchoBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserToReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConversationId = c.String(),
                        SkypeUserId = c.String(),
                        SkypeUserName = c.String(),
                        Email = c.String(),
                        SendEmail = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserToReplies");
            DropTable("dbo.SearchKeys");
            DropTable("dbo.Recipients");
        }
    }
}
