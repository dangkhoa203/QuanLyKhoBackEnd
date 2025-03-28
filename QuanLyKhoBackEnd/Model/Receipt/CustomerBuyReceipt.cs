using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Form;
using QuanLyKhoBackEnd.Model.Enum;

namespace QuanLyKhoBackEnd.Model.Receipt {
    public class CustomerBuyReceipt : EntityGeneric {
        public required DateTime DateOrder { get; set; }
        public required float ReceiptValue { get; set; }

        public CustomerBuyReceipt() {
            Id = $"HDMUAHANG-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";

        }

        public virtual ICollection<ExportForm>? StockExportReport { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CustomerBuyReceiptDetail> Details { get; set; }
    }
}
