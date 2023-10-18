using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBlogs.Models
{
    public partial class blogsContext : DbContext
    {
        public blogsContext()
        {
        }

        public blogsContext(DbContextOptions<blogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=blogs;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Salt)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Accounts__RoleID__398D8EEE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Categori__6A1C8ADAD91B2D4E");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.CatName).HasMaxLength(255);

                entity.Property(e => e.Cover)
                    .HasMaxLength(255)
                    .HasColumnName("cover");

                entity.Property(e => e.Icon).HasMaxLength(255);

                entity.Property(e => e.Levels).HasColumnName("levels");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Thumb).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .HasColumnName("alias");

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.IsHot).HasColumnName("isHot");

                entity.Property(e => e.IsNewfeed).HasColumnName("isNewfeed");

                entity.Property(e => e.Scontent)
                    .HasMaxLength(255)
                    .HasColumnName("SContent");

                entity.Property(e => e.Thumb).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__News__AccountID__3E52440B");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__News__CatID__3F466844");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleDescription).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
