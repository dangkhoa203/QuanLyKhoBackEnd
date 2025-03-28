using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Receipt;
using System.ComponentModel.DataAnnotations;
using QuanLyKhoBackEnd.Model.Entity.Product_Entity;

namespace QuanLyKhoBackEnd.Model.Entity.Vendor_Entity {
    public class Vendor : EntityGeneric {
        public required string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Vendor() : base() {
            Id = $"NCC-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";
        }
        public virtual ICollection<VendorReplenishReceipt>? VendorReplenishReceipts { get; set; }
        public virtual VendorGroup? VendorGroup { get; set; }
    }
}
