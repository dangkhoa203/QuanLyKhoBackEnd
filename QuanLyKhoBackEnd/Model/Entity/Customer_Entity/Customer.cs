using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using QuanLyKhoBackEnd.Model.Receipt;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoBackEnd.Model.Entity.Customer_Entity {
    public class Customer : EntityGeneric {
        public required string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Customer() : base() {
            Id = $"KH-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";
        }
        public virtual CustomerGroup? CustomerGroup { get; set; }

        public virtual ICollection<CustomerBuyReceipt>? CustomerBuyReceipts { get; set; }

    }
}
