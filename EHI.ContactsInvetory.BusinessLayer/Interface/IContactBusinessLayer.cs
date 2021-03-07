using EHI.ContactsInvetory.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EHI.ContactsInvetory.BusinessLayer
{
    public interface IContactBusinessLayer
    {
        Task<Contact> GetContact(int id);

        Task<IEnumerable<Contact>> GetContacts();

        Task<Contact> AddContact(Contact contact);

        Task<Contact> UpdateContact(Contact contact);

        Task<bool> DeleteContact(int id);
    }
}
