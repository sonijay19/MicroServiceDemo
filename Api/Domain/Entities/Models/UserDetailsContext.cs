using System;
using Api.Domain.Dtos.InsertUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Api.Domain.Entities.Models
{
    public partial class UserDetailsContext : DbContext
    {
        public IConfiguration connectionConfig;
        public UserDetailsContext(IConfiguration configuration)
        {
            connectionConfig = configuration;
        }
        public UserDetailsContext()
        {
        }

        public UserDetailsContext(DbContextOptions<UserDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserTypeStatus> UserTypeStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=UserDetails;User ID = DESKTOP-02T0GUH\\\\\\\\sonij; Password='';Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C7BA7776F");

                entity.HasIndex(e => e.UserEmail, "UQ__UserDeta__08638DF846A31C91")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__UserDeta__85FB4E389DB520BE")
                    .IsUnique();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserDetai__UserT__7C4F7684");
            });

            modelBuilder.Entity<UserTypeStatus>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__UserType__516F03B5D0C548A6");

                entity.ToTable("UserTypeStatus");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
