using QuanLyKhoBackEnd.Model.Entity.Product_Entity;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoBackEnd.Model.Entity.Warehouse_Entity {
    public class Stock {
        public string ProductId { get; set; }
        public Product? ProductNav { get; set; }
        public required string ServiceId { get; set; }
        public required int Quantity { get; set; }

    }
}
