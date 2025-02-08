using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practic.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<PartenersType> PartenersTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=221-007;DataBase=ispp1113_2;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.HasIndex(e => e.Login, "IX_Account").IsUnique();

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Percent).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        modelBuilder.Entity<PartenersType>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(10);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasIndex(e => e.Type, "IX_Partners_Type");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Director).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INN");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Partners_PartenersTypes");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasIndex(e => e.PartnerId, "IX_PartnersProducts_PartnerId");

            entity.HasIndex(e => e.ProductId, "IX_PartnersProducts_ProductId");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnersProducts_Partners");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartnersProducts_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.ProductTypeId, "IX_Products_ProductTypeId");

            entity.Property(e => e.Articul)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MinPrice).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Title).HasMaxLength(60);

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductType");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("ProductType");

            entity.Property(e => e.Coefficient).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
