using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;

namespace QuanLyKhoBackEnd.Model.Entity.Product_Entity {
    public class ProductType : EntityGeneric {
        public required string Name { get; set; }
        public string Description { get; set; }

        public ProductType() : base() {
            Id = $"LOAISP-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";
        }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
