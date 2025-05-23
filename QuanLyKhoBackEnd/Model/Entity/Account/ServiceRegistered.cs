﻿using Microsoft.Identity.Client;
using NanoidDotNet;
using System.ComponentModel.DataAnnotations;
using QuanLyKhoBackEnd.Model.Entity.Customer_Entity;

namespace QuanLyKhoBackEnd.Model.Entity.Account {
    public class ServiceRegistered {
        [Key]
        public string Id { get; set; }
        public ServiceRegistered() {
            Id = $"SERVICE-{Nanoid.Generate(Nanoid.Alphabets.LowercaseLettersAndDigits, 4)}";
        }
        public virtual ICollection<Account>? Accounts { get; set; }

    }
}
