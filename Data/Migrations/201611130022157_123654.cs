namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123654 : DbMigration
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
                .ForeignKey("dbo.user", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FirstName = c.String(unicode: false),
                        Lastname = c.String(unicode: false),
                        Birthday = c.DateTime(nullable: false, precision: 0),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        RIB = c.String(unicode: false),
                        Gender = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
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
                .Index(t => t.CollocationOffreId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GroupCollocation",
                c => new
                    {
                        CollocationGroupId = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        NombreDeMebre = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        GroupeType = c.String(unicode: false),
                        Student_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CollocationGroupId)
                .ForeignKey("dbo.user", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
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
                "dbo.discution",
                c => new
                    {
                        DiscutionGroupId = c.Int(nullable: false, identity: true),
                        Titre = c.String(unicode: false),
                        Text = c.String(unicode: false),
                        CollocationGroupId = c.Int(nullable: false),
                        UserIden = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DiscutionGroupId)
                .ForeignKey("dbo.GroupCollocation", t => t.CollocationGroupId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.UserIden)
                .Index(t => t.CollocationGroupId)
                .Index(t => t.UserIden);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
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
                .ForeignKey("dbo.user", t => t.AppartementOwnerId)
                .Index(t => t.AppartementOwnerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
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
                .ForeignKey("dbo.GroupCollocation", t => t.CollocationGroup_CollocationGroupId, cascadeDelete: true)
                .Index(t => t.CollocationOffre_CollocationOffreId)
                .Index(t => t.CollocationGroup_CollocationGroupId);
            
            CreateTable(
                "dbo.ColloGroups_users",
                c => new
                    {
                        user_fk = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        group_fk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_fk, t.group_fk })
                .ForeignKey("dbo.user", t => t.user_fk, cascadeDelete: true)
                .ForeignKey("dbo.GroupCollocation", t => t.group_fk, cascadeDelete: true)
                .Index(t => t.user_fk)
                .Index(t => t.group_fk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.user", "CollocationOffreId", "dbo.CollocationOffre");
            DropForeignKey("dbo.GroupCollocation", "Student_Id", "dbo.user");
            DropForeignKey("dbo.discution", "UserIden", "dbo.user");
            DropForeignKey("dbo.Appartement", "AppartementOwnerId", "dbo.user");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.user");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.user");
            DropForeignKey("dbo.ColloGroups_users", "group_fk", "dbo.GroupCollocation");
            DropForeignKey("dbo.ColloGroups_users", "user_fk", "dbo.user");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.user");
            DropForeignKey("dbo.discution", "CollocationGroupId", "dbo.GroupCollocation");
            DropForeignKey("dbo.CollocationOffreCollocationGroup", "CollocationGroup_CollocationGroupId", "dbo.GroupCollocation");
            DropForeignKey("dbo.CollocationOffreCollocationGroup", "CollocationOffre_CollocationOffreId", "dbo.CollocationOffre");
            DropForeignKey("dbo.Alert", "StudentId", "dbo.user");
            DropIndex("dbo.ColloGroups_users", new[] { "group_fk" });
            DropIndex("dbo.ColloGroups_users", new[] { "user_fk" });
            DropIndex("dbo.CollocationOffreCollocationGroup", new[] { "CollocationGroup_CollocationGroupId" });
            DropIndex("dbo.CollocationOffreCollocationGroup", new[] { "CollocationOffre_CollocationOffreId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Appartement", new[] { "AppartementOwnerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.discution", new[] { "UserIden" });
            DropIndex("dbo.discution", new[] { "CollocationGroupId" });
            DropIndex("dbo.GroupCollocation", new[] { "Student_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.user", new[] { "CollocationOffreId" });
            DropIndex("dbo.Alert", new[] { "StudentId" });
            DropTable("dbo.ColloGroups_users");
            DropTable("dbo.CollocationOffreCollocationGroup");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Appartement");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.discution");
            DropTable("dbo.CollocationOffre");
            DropTable("dbo.GroupCollocation");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.user");
            DropTable("dbo.Alert");
        }
    }
}
