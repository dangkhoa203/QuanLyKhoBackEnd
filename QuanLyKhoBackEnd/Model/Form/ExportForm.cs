using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Receipt;
using QuanLyKhoBackEnd.Model.Entity;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Model.Form {
    public class ExportForm : EntityGeneric {
        public string ReceiptId { get; set; }
        public required DateTime ExportDate { get; set; }

        public ExportForm() : base() {
            Id = $"XUATKHO-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";

        }
        public virtual CustomerBuyReceipt Receipt { get; set; }
        public virtual ICollection<ExportFormDetail> Details { get; set; }
    }
}
