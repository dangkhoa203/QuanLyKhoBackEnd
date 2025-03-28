using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace QuanLyKhoBackEnd.Model.Entity.Account {
    public class Account : IdentityUser {
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public string ServiceId { get; set; }
        public virtual ServiceRegistered ServiceRegistered { get; set; }
        public Account() {
            DateCreated = DateTime.Now;
        }
    }
}
