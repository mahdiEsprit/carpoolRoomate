namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n145 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alert",
                c => new
                    {
                        AlertId = c.Int(nullable: false, identity: true),
                        Frequency = c.String(unicode: false),
                        IsEnable = c.Boolean(nullable: false),
                        StudentId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AlertId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FirstName = c.String(unicode: false),
                        Lastname = c.String(unicode: false),
                        Birthday = c.DateTime(nullable: false, precision: 0),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        RIB = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        Email = c.String(maxLength: 254, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 254, storeType: "nvarchar"),
                        Country = c.String(unicode: false),
                        Street = c.String(unicode: false),
                        MainActivity = c.String(unicode: false),
                        Hobbies = c.String(unicode: false),
                        Smoker = c.Boolean(),
                        Picture = c.String(unicode: false),
                        ZipCode = c.Int(),
                        CollocationOffreId = c.Int(),
                        TypeOfRental = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollocationOffre", t => t.CollocationOffreId, cascadeDelete: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.CollocationOffreId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CollocationGroup",
                c => new
                    {
                        CollocationGroupId = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CollocationGroupId);
            
            CreateTable(
                "dbo.CollocationOffre",
                c => new
                    {
                        CollocationOffreId = c.Int(nullable: false, identity: true),
                        Titre = c.String(unicode: false),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        Region = c.String(unicode: false),
                        adress_Ville = c.String(unicode: false),
                        adress_Rue = c.String(unicode: false),
                        adress_CodePostal = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CollocationOffreId);
            
            CreateTable(
                "dbo.DiscutionGroup",
                c => new
                    {
                        DiscutionGroupId = c.Int(nullable: false, identity: true),
                        Titre = c.String(unicode: false),
                        Text = c.String(unicode: false),
                        CollocationGroupId = c.String(unicode: false),
                        collocationGroup_CollocationGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.DiscutionGroupId)
                .ForeignKey("dbo.CollocationGroup", t => t.collocationGroup_CollocationGroupId)
                .Index(t => t.collocationGroup_CollocationGroupId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Appartement",
                c => new
                    {
                        AppartementId = c.Int(nullable: false, identity: true),
                        adresseAppartement_Ville = c.String(unicode: false),
                        adresseAppartement_Rue = c.String(unicode: false),
                        adresseAppartement_CodePostal = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Description = c.String(unicode: false),
                        Price = c.Single(nullable: false),
                        Islocated = c.Boolean(nullable: false),
                        rentaltype = c.String(unicode: false),
                        AppartementOwnerId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AppartementId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppartementOwnerId)
                .Index(t => t.AppartementOwnerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 254, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CollocationOffreCollocationGroup",
                c => new
                    {
                        CollocationOffre_CollocationOffreId = c.Int(nullable: false),
                        CollocationGroup_CollocationGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CollocationOffre_CollocationOffreId, t.CollocationGroup_CollocationGroupId })
                .ForeignKey("dbo.CollocationOffre", t => t.CollocationOffre_CollocationOffreId, cascadeDelete: true)
                .ForeignKey("dbo.CollocationGroup", t => t.CollocationGroup_CollocationGroupId, cascadeDelete: true)
                .Index(t => t.CollocationOffre_CollocationOffreId)
                .Index(t => t.CollocationGroup_CollocationGroupId);
            
            CreateTable(
                "dbo.CollocationGroupStudent",
                c => new
                    {
                        CollocationGroup_CollocationGroupId = c.Int(nullable: false),
                        Student_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.CollocationGroup_CollocationGroupId, t.Student_Id })
                .ForeignKey("dbo.CollocationGroup", t => t.CollocationGroup_CollocationGroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.CollocationGroup_CollocationGroupId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Appartement", "AppartementOwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CollocationGroupStudent", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CollocationGroupStudent", "CollocationGroup_CollocationGroupId", "dbo.CollocationGroup");
            DropForeignKey("dbo.DiscutionGroup", "collocationGroup_CollocationGroupId", "dbo.CollocationGroup");
            DropForeignKey("dbo.AspNetUsers", "CollocationOffreId", "dbo.CollocationOffre");
            DropForeignKey("dbo.CollocationOffreCollocationGroup", "CollocationGroup_CollocationGroupId", "dbo.CollocationGroup");
            DropForeignKey("dbo.CollocationOffreCollocationGroup", "CollocationOffre_CollocationOffreId", "dbo.CollocationOffre");
            DropForeignKey("dbo.Alert", "StudentId", "dbo.AspNetUsers");
            DropIndex("dbo.CollocationGroupStudent", new[] { "Student_Id" });
            DropIndex("dbo.CollocationGroupStudent", new[] { "CollocationGroup_CollocationGroupId" });
            DropIndex("dbo.CollocationOffreCollocationGroup", new[] { "CollocationGroup_CollocationGroupId" });
            DropIndex("dbo.CollocationOffreCollocationGroup", new[] { "CollocationOffre_CollocationOffreId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Appartement", new[] { "AppartementOwnerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.DiscutionGroup", new[] { "collocationGroup_CollocationGroupId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CollocationOffreId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Alert", new[] { "StudentId" });
            DropTable("dbo.CollocationGroupStudent");
            DropTable("dbo.CollocationOffreCollocationGroup");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Appartement");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.DiscutionGroup");
            DropTable("dbo.CollocationOffre");
            DropTable("dbo.CollocationGroup");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Alert");
        }
    }
}
