using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practice_proyect.Models;

public partial class FirstContext : DbContext
{
    public FirstContext()
    {
    }

    public FirstContext(DbContextOptions<FirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=first;User Id=postgres;Password=jav123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("parents_pkey");

            entity.ToTable("parents");

            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.ParentName)
                .HasMaxLength(50)
                .HasColumnName("parent_name");
            entity.Property(e => e.ParentStatus).HasColumnName("parent_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserUsername, "users_user_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserStatus).HasColumnName("user_status");
            entity.Property(e => e.UserUsername)
                .HasMaxLength(20)
                .HasColumnName("user_username");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehiId).HasName("vehicles_pkey");

            entity.ToTable("vehicles");

            entity.Property(e => e.VehiId).HasColumnName("vehi_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VehiBrand)
                .HasMaxLength(50)
                .HasColumnName("vehi_brand");

            entity.HasOne(d => d.User).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("vehicles_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
