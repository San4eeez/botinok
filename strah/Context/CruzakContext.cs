using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using strah.Models;

namespace strah.Context;

public partial class CruzakContext : DbContext
{
    public CruzakContext()
    {
    }

    public CruzakContext(DbContextOptions<CruzakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Deliveypoint> Deliveypoints { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordersproduct> Ordersproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Cruzak;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category", "public5");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Categoryname).HasColumnName("categoryname");
        });

        modelBuilder.Entity<Deliveypoint>(entity =>
        {
            entity.HasKey(e => e.PointId).HasName("deliveypoints_pkey");

            entity.ToTable("deliveypoints", "public5");

            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.Pointname).HasColumnName("pointname");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturers_pkey");

            entity.ToTable("manufacturers", "public5");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Manufacturername).HasColumnName("manufacturername");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("orders", "public5");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.PointId).HasColumnName("point_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Point).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PointId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_point_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_status_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orders_user_id_fkey");
        });

        modelBuilder.Entity<Ordersproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ordersproducts_pkey");

            entity.ToTable("ordersproducts", "public5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ordersproducts_order_id_fkey");

            entity.HasOne(d => d.Products).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ordersproducts_products_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products", "public5");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Article).HasColumnName("article");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Countinstock).HasColumnName("countinstock");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Productname).HasColumnName("productname");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("products_category_id_fkey");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("products_manufacturer_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("products_supplier_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles", "public5");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Rolename).HasColumnName("rolename");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("status_pkey");

            entity.ToTable("status", "public5");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Statusname).HasColumnName("statusname");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("suppliers_pkey");

            entity.ToTable("suppliers", "public5");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Suppliername).HasColumnName("suppliername");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users", "public5");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
