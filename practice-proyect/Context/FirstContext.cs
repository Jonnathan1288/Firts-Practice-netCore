using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using practice_proyect.Model;

namespace practice_proyect.Context;

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
