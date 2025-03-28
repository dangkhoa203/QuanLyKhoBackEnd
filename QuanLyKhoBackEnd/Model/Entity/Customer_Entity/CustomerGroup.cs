using Microsoft.EntityFrameworkCore;
using NanoidDotNet;
using QuanLyKhoBackEnd.Model.Entity.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoBackEnd.Model.Entity.Customer_Entity {
    public class CustomerGroup : EntityGeneric {
        public required string Name { get; set; }
        public string Description { get; set; }
        public CustomerGroup() : base() {
            Id = $"NHOMKH-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 5)}";
        }
        public virtual ICollection<Customer>? Customers { get; set; }


    }
}
