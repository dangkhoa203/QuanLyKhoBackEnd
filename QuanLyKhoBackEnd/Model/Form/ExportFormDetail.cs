using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity;

namespace QuanLyKhoBackEnd.Model.Form {
    public class ExportFormDetail {
        public string ProductId { get; set; }
        public string FormId { get; set; }
        public required int Quantity { get; set; }
        public virtual Product ProductNav { get; set; }
        public virtual ExportForm FormNav { get; set; }
    }
}
