using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Entity.Vendor_Entity;
using QuanLyKhoBackEnd.Model.Form;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Model.Receipt {
    public class VendorReplenishReceipt : EntityGeneric {
        public required DateTime DateOrder { get; set; }
        public required float ReceiptValue { get; set; }

        public VendorReplenishReceipt() {
            Id = $"HDNHAPHANG-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";

        }

        public virtual ICollection<ImportForm>? StockImportReport { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<VendorReplenishReceiptDetail> Details { get; set; }
    }
}
