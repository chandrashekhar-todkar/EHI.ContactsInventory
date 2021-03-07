using EHI.ContactsInvetory.Dto;
using Microsoft.EntityFrameworkCore;

namespace EHI.ContactsInvetory.DataAccess
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
