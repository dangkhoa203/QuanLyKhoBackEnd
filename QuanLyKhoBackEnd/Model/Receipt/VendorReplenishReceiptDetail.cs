using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoBackEnd.Model.Receipt {
    public class VendorReplenishReceiptDetail {
        public string ProductId { get; set; }
        public string ReceiptId { get; set; }
        public int Quantity { get; set; }
        public float PriceOfOne { get; set; }
        public float TotalPrice { get; set; }
        public virtual Product ProductNav { get; set; }
        public virtual VendorReplenishReceipt ReceiptNav { get; set; }

    }
}
