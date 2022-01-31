namespace ECovidVerify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECovidVerifyMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientInfo", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "MiddleName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "DateOfBirth", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.PatientInfo", "Gender", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "PhoneNumber", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PatientInfo", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientInfo", "Address", c => c.String());
            AlterColumn("dbo.PatientInfo", "Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.PatientInfo", "PhoneNumber", c => c.String(maxLength: 128));
            AlterColumn("dbo.PatientInfo", "Gender", c => c.String(maxLength: 128));
            AlterColumn("dbo.PatientInfo", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.PatientInfo", "MiddleName", c => c.String(maxLength: 128));
            AlterColumn("dbo.PatientInfo", "LastName", c => c.String(maxLength: 128));
            AlterColumn("dbo.PatientInfo", "FirstName", c => c.String(maxLength: 128));
        }
    }
}
