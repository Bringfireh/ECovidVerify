namespace ECovidVerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        QuestionId = c.String(maxLength: 128),
                        PatientInfoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInfo", t => t.PatientInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId)
                .Index(t => t.PatientInfoId);
            
            CreateTable(
                "dbo.PatientInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        MiddleName = c.String(maxLength: 128),
                        DateOfBirth = c.DateTime(),
                        Gender = c.String(maxLength: 128),
                        PhoneNumber = c.String(maxLength: 128),
                        Email = c.String(maxLength: 128),
                        Address = c.String(),
                        City = c.String(maxLength: 128),
                        Zip = c.String(maxLength: 128),
                        Race = c.String(maxLength: 128),
                        Ethnicity = c.String(maxLength: 128),
                        HealthInsurance = c.Boolean(),
                        CHName = c.String(maxLength: 128),
                        CHDateOfBirth = c.DateTime(),
                        CHEmployer = c.String(maxLength: 128),
                        InsuranceCompany = c.String(maxLength: 128),
                        MemberID = c.String(maxLength: 128),
                        GroupNo = c.String(maxLength: 128),
                        NameOfInsured = c.String(maxLength: 128),
                        RelationshipToInsured = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VaccineInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PatientInfoId = c.String(maxLength: 128),
                        DateOfVaccination = c.DateTime(),
                        VaccineType = c.String(maxLength: 128),
                        Jab = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PatientInfo", t => t.PatientInfoId, cascadeDelete: true)
                .Index(t => t.PatientInfoId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        QuestionText = c.String(),
                        Rank = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.VaccineInfo", "PatientInfoId", "dbo.PatientInfo");
            DropForeignKey("dbo.Answer", "PatientInfoId", "dbo.PatientInfo");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VaccineInfo", new[] { "PatientInfoId" });
            DropIndex("dbo.Answer", new[] { "PatientInfoId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Question");
            DropTable("dbo.VaccineInfo");
            DropTable("dbo.PatientInfo");
            DropTable("dbo.Answer");
        }
    }
}
