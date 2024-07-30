using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserManagementAssignmentBE.Models;

public partial class SDirectContext : DbContext
{
    public SDirectContext()
    {
    }

    public SDirectContext(DbContextOptions<SDirectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GautamUser> GautamUsers { get; set; }

    public virtual DbSet<TempAddress> TempAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=172.24.0.101;Database=sDirect;User Id=sDirect;Password=sDirect;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GautamUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__GautamUs__1788CCACAFD0CC21");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AlternatePhone)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmailKey).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PassKey).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(44)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.TempAddress).WithMany(p => p.GautamUsers)
                .HasForeignKey(d => d.TempAddressId)
                .HasConstraintName("FK__GautamUse__TempA__70E8B0D0");
        });

        modelBuilder.Entity<TempAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TempAddr__3214EC07D07C0AEA");

            entity.ToTable("TempAddress");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(44)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
