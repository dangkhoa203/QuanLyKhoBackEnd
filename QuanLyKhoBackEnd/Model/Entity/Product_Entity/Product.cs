using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;
using QuanLyKhoBackEnd.Model.Form;
using QuanLyKhoBackEnd.Model.Receipt;
using QuanLyKhoBackEnd.Model.Entity.Vendor_EntiTy;


namespace QuanLyKhoBackEnd.Model.Entity.Product_Entity {
    public class Product : EntityGeneric {
        public required string Name { get; set; }
        public required float PricePerUnit { get; set; }
        public required string MeasureUnit { get; set; }
        public Product() : base() {
            Id = $"SP-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";
        }
        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<VendorReplenishReceiptDetail>? VendorReplenishReceiptDetails { get; set; }
        public virtual ICollection<CustomerBuyReceiptDetail>? CustomerBuyReceiptDetails { get; set; }
        public virtual ICollection<ImportFormDetail>? ImportDetails { get; set; }
        public virtual ICollection<ExportFormDetail>? ExportDetails { get; set; }
        public virtual ICollection<Stock>? Stocks { get; set; }
    }
}
