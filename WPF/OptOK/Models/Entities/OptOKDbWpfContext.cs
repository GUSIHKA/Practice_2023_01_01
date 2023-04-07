using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OptOK.Models.Entities;

public partial class OptOKDbWpfContext : DbContext
{
    public OptOKDbWpfContext()
    {
    }

    public OptOKDbWpfContext(DbContextOptions<OptOKDbWpfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<DisplayedCharacteristic> DisplayedCharacteristics { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderContent> OrderContents { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Outpost> Outposts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#pragma warning disable CS1030 // Директива #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    { optionsBuilder.UseSqlServer("Data source=WIN-5QHSJKLV9J6\\MSSQLSERVER2; Database=OptOKDB_WPF; Persist Security Info=False; Trusted_Connection=True; TrustServerCertificate=True");
#pragma warning restore CS1030 // Директива #warning
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC27832BCDBF");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName).HasMaxLength(250);

            entity.HasMany(d => d.Characteristics).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryCharacteristic",
                    r => r.HasOne<Characteristic>().WithMany()
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryC__Chara__3F466844"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryC__Categ__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("CategoryId", "CharacteristicId").HasName("PK__Category__F5079EF1F8D5AE7E");
                        j.ToTable("CategoryCharacteristic");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                        j.IndexerProperty<int>("CharacteristicId").HasColumnName("CharacteristicID");
                    });
        });

        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC27D1B4F861");

            entity.ToTable("Characteristic");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CharacteristicName).HasMaxLength(200);
        });

        modelBuilder.Entity<DisplayedCharacteristic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Displaye__3214EC2797921482");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CharacteristicId).HasColumnName("CharacteristicID");

            entity.HasOne(d => d.Category).WithMany(p => p.DisplayedCharacteristics)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Displayed__Categ__403A8C7D");

            entity.HasOne(d => d.Characteristic).WithMany(p => p.DisplayedCharacteristics)
                .HasForeignKey(d => d.CharacteristicId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Displayed__Chara__412EB0B6");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC27892268A9");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ClientFullName).HasMaxLength(200);
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OutpostId).HasColumnName("OutpostID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Outpost).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OutpostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__OutpostID__4222D4EF");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__StatusID__4316F928");
        });

        modelBuilder.Entity<OrderContent>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.OrderId }).HasName("PK__OrderCon__5835C3775198DAB6");

            entity.ToTable("OrderContent");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderContents)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderCont__Order__440B1D61");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderContents)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderCont__Produ__44FF419A");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC279D56CDE0");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Outpost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Outpost__3214EC27FA0EFBC7");

            entity.ToTable("Outpost");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(200);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC27E2780765");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("decimal(16, 4)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductCharacteristic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC27EDC4887F");

            entity.ToTable("ProductCharacteristic");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CharacteristicId).HasColumnName("CharacteristicID");
            entity.Property(e => e.CharacteristicValue).HasMaxLength(200);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Unit).HasMaxLength(30);

            entity.HasOne(d => d.Characteristic).WithMany(p => p.ProductCharacteristics)
                .HasForeignKey(d => d.CharacteristicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCh__Chara__5441852A");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCharacteristics)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductCh__Produ__534D60F1_Cascade");
        });

        modelBuilder.Entity<ProductPicture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC0713DBD9E3");

            entity.ToTable("ProductPicture");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ProductPi__Produ__4F7CD00D");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC273A3F3DEC");

            entity.ToTable("ProductPrice");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(16, 4)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductPr__Produ__5070F446");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC27C1FAF7BB");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC274F69DED8");

            entity.ToTable("User");

            entity.HasIndex(e => e.Login, "UQ__User__5E55825BF88674FB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Surename).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleID__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
