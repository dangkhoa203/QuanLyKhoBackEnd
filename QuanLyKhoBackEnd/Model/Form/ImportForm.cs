using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Receipt;
using QuanLyKhoBackEnd.Model.Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Model.Form {
    public class ImportForm : EntityGeneric {
        public string ReceiptId { get; set; }
        public required DateTime ImportDate { get; set; }

        public ImportForm() : base() {
            Id = $"NHAPKHO-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";

        }

        public virtual VendorReplenishReceipt Receipt { get; set; }
        public virtual ICollection<ImportFormDetail> Details { get; set; }
    }
}
