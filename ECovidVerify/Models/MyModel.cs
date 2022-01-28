//namespace ECovidVerify.Models
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class MyModel : DbContext
//    {
//        public MyModel()
//            : base("name=MyModel")
//        {
//        }

//        public virtual DbSet<Answer> Answer { get; set; }
//        public virtual DbSet<PatientInfo> PatientInfo { get; set; }
//        public virtual DbSet<Question> Question { get; set; }
//        public virtual DbSet<VaccineInfo> VaccineInfo { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<PatientInfo>()
//                .HasMany(e => e.Answer)
//                .WithOptional(e => e.PatientInfo)
//                .WillCascadeOnDelete();

//            modelBuilder.Entity<PatientInfo>()
//                .HasMany(e => e.VaccineInfo)
//                .WithOptional(e => e.PatientInfo)
//                .WillCascadeOnDelete();
//        }
//    }
//}
