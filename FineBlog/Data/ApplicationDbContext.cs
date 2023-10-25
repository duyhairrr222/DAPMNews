using FineBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FineBlog.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Page>? Pages { get; set; }
        public DbSet<Setting>? Settings { get; set; }
        public DbSet<Category> Categorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(t => t.CateID);
             modelBuilder.Entity<Category>()
            .HasKey(c => c.CateID); // Replace 'CategoryId' with the actual primary key property of your 'Category' entity

            // Other entity configurations go here

            base.OnModelCreating(modelBuilder);
        }
    }
}
