using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using QuanLyKhoBackEnd.Model.Entity.Account;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Entity.Vendor_Entity;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;
using QuanLyKhoBackEnd.Model.Form;
using QuanLyKhoBackEnd.Model.Receipt;
namespace QuanLyKhoBackEnd.Data {
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>(entity =>
            entity.HasOne(e => e.ServiceRegistered)
                  .WithMany(s => s.Accounts)
                  .HasForeignKey(e => e.ServiceId)
            );
            builder.Entity<ProductType>(entity =>
            {
                entity.HasMany(u => u.Products)
                      .WithOne(p => p.ProductType)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<CustomerGroup>(entity =>
            {
                entity.HasMany(u => u.Customers)
                      .WithOne(p => p.CustomerGroup)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<VendorGroup>(entity =>
            {
                entity.HasMany(u => u.Vendors)
                      .WithOne(p => p.VendorGroup)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<VendorReplenishReceiptDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ReceiptId });

                entity.HasOne(d => d.ProductNav)
                    .WithMany(p => p.VendorReplenishReceiptDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_replenishdetail_product");

                entity.HasOne(d => d.ReceiptNav)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_replenishdetail_receipt");
            });
            builder.Entity<CustomerBuyReceiptDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ReceiptId });

                entity.HasOne(d => d.ProductNav)
                    .WithMany(p => p.CustomerBuyReceiptDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderdetail_product");

                entity.HasOne(d => d.ReceiptNav)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderdetail_receipt");
            });
            builder.Entity<Stock>(entity => {
                entity.HasKey(e => new { e.ProductId });

                entity.HasOne(s => s.ProductNav)
                   .WithMany(p => p.Stocks)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stock_product");

            });
           

           
            builder.Entity<ImportFormDetail>(entity => {
                entity.HasKey(e => new { e.ProductId, e.FormId });

                entity.HasOne(d => d.ProductNav)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_importdetail_product");

                entity.HasOne(d => d.FormNav)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_importdetail_form");
            });
         
            builder.Entity<ExportFormDetail>(entity => {
                entity.HasKey(e => new { e.ProductId, e.FormId });

                entity.HasOne(d => d.ProductNav)
                    .WithMany(p => p.ExportDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exportdetail_product");

                entity.HasOne(d => d.FormNav)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exportdetail_form");
              
            });
            base.OnModelCreating(builder);
        }
      
        public virtual DbSet<ServiceRegistered> ServiceRegistereds { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }
        public virtual DbSet<CustomerBuyReceipt> CustomerBuyReceipts { get; set; }
        public virtual DbSet<CustomerBuyReceiptDetail> CustomerBuyReceiptDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorGroup> VendorGroups { get; set; }
        public virtual DbSet<VendorReplenishReceipt> VendorReplenishReceipts { get; set; }
        public virtual DbSet<VendorReplenishReceiptDetail> VendorReplenishReceiptDetails { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<ExportFormDetail> ExportDetails { get; set; }
        public virtual DbSet<ExportForm> ExportForms { get; set; }
        public virtual DbSet<ImportFormDetail> ImportDetails { get; set; }
        public virtual DbSet<ImportForm> ImportForms { get; set; }


    }
}
