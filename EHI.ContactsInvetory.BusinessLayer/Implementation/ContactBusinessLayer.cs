using EHI.ContactsInvetory.DataAccess.Repository;
using EHI.ContactsInvetory.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EHI.ContactsInvetory.BusinessLayer
{
    public class ContactBusinessLayer : IContactBusinessLayer
    {
        private readonly IContactRepository _contactRepository = null;
        public ContactBusinessLayer(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _contactRepository.GetContact(id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactRepository.GetContacts();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            return await _contactRepository.AddContact(contact); 
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            return await _contactRepository.UpdateContact(contact);
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await _contactRepository.DeleteContact(id); ;
        }
    }
}
