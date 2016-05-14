using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Foundation_initiatives.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PointsCount { get; set; }
        public string Photo { get; set; }
        public string About { get; set; }
        public bool IsFree { get; set; }


        public virtual ICollection<Step> Steps { get; set; }

        public ApplicationUser()
        {
            Steps = new List<Step>();
        }

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
        public DbSet<Initiative> Initiatives { get; set; }
        public DbSet<Step> Steps { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Step>().HasMany(c => c.Members)
        //        .WithMany(s => s.Steps)
        //        .Map(t => t.MapLeftKey("StepId")
        //        .MapRightKey("MemberId")
        //        .ToTable("StepMember"));
                
        //}
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}