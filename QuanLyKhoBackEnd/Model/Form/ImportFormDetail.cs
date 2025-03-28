using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;
using QuanLyKhoBackEnd.Model.Receipt;

namespace QuanLyKhoBackEnd.Model.Form {
    public class ImportFormDetail {
        public string ProductId { get; set; }
        public string FormId { get; set; }
        public required int Quantity { get; set; }
        public virtual Product ProductNav { get; set; }
        public virtual ImportForm FormNav { get; set; }
    }
}
