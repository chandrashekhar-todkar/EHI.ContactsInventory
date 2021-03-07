using EHI.ContactsInvetory.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHI.ContactsInvetory.DataAccess.Repository
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(ContactContext dbContext) : base(dbContext)
        { }

        public async Task<Contact> GetContact(int id)
        {
            return await _dbContext.Set<Contact>().FirstOrDefaultAsync(c => c.Id == id && c.Status == "Active");
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _dbContext.Set<Contact>().Where(c => c.Status == "Active").ToListAsync();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            contact.Status = "Active";
            contact.DateUpdated = DateTime.UtcNow;
            _dbContext.Set<Contact>().Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            contact.DateUpdated = DateTime.UtcNow;
            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _dbContext.Set<Contact>().FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            contact.DateUpdated = DateTime.UtcNow;
            contact.Status = "InActive";
            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
