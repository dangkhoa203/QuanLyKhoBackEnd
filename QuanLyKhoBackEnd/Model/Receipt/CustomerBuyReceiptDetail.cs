using QuanLyKhoBackEnd.Model.Entity.Product_Entity;

namespace QuanLyKhoBackEnd.Model.Receipt {
    public class CustomerBuyReceiptDetail {
        public string ProductId { get; set; }
        public string ReceiptId { get; set; }
        public int Quantity { get; set; }
        public float PriceOfOne { get; set; }
        public float TotalPrice { get; set; }
        public virtual Product ProductNav { get; set; }
        public virtual CustomerBuyReceipt ReceiptNav { get; set; }

    }
}
