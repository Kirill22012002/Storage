using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Storage.DbModels;

#nullable disable

namespace Storage.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cell> Cells { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomersProduct> CustomersProducts { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Storage;User Id=sa;Password=Contraseña12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Cell>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<CustomersProduct>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK__Customers__idCus__412EB0B6");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__Customers__idPro__4222D4EF");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasIndex(e => e.Barcode, "UQ_Part_Barcode")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("barcode");

                entity.Property(e => e.Datefiling)
                    .HasColumnType("datetime")
                    .HasColumnName("datefiling");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__Parts__idProduct__3A81B327");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductCategory");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__ProductCa__idCat__5DCAEF64");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__ProductCa__idPro__5EBF139D");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdCell).HasColumnName("idCell");

                entity.Property(e => e.IdPart).HasColumnName("idPart");

                entity.HasOne(d => d.IdCellNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCell)
                    .HasConstraintName("FK__Records__idCell__3C69FB99");

                entity.HasOne(d => d.IdPartNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPart)
                    .HasConstraintName("FK__Records__idPart__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
