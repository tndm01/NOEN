using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NOEN.Model.Models;

namespace NOEN.Data
{
    public class NOENdbContext : IdentityDbContext<ApplicationUser>
    {
        public NOENdbContext() : base("NOENConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ContactDetail> ContactDetails { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnline { set; get; }
        public DbSet<SystemConfig> SystemConfig { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<VistorStatistic> VistorStatistics { set; get; }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }

        public static NOENdbContext Create()
        {
            return new NOENdbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(x => new { x.UserId, x.RoleId }).ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(x => x.UserId).ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(x => x.UserId).ToTable("ApplicationUserClaims");
        }
    }
}