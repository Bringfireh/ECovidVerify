using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ECovidVerify.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<PatientInfo> PatientInfo { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<VaccineInfo> VaccineInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientInfo>()
                .HasMany(e => e.Answer)
                .WithOptional(e => e.PatientInfo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PatientInfo>()
                .HasMany(e => e.VaccineInfo)
                .WithOptional(e => e.PatientInfo)
                .WillCascadeOnDelete();
        }
    }
}