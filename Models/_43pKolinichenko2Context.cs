using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Models;

public partial class _43pKolinichenko2Context : DbContext
{
    public _43pKolinichenko2Context()
    {
    }

    public _43pKolinichenko2Context(DbContextOptions<_43pKolinichenko2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.ru;Port=5442;Database=43P_Kolinichenko2;Username=43P;Password=444444");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_users_pkey");

            entity.ToTable("role_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Passvord).HasColumnName("passvord");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
