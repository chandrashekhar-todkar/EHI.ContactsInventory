using EHI.ContactsInvetory.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace EHI.ContactsInvetory.Web.Models
{
    public class ContactModel
    {
        private readonly Uri _baseAddress;

        public ContactModel(IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("apiBaseUrl");
            _baseAddress = new Uri(url);
        }

        public async Task<Contact> GetContact(int id)
        {
            Contact contact = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                //HTTP GET
                var result = await client.GetAsync("contact/" + id.ToString());

                if (result.IsSuccessStatusCode)
                {
                    contact = await result.Content.ReadAsAsync<Contact>();
                 }
            }

            return contact;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            IList<Contact> contacts = new List<Contact>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                //HTTP GET
                var result = await client.GetAsync("contact");

                if (result.IsSuccessStatusCode)
                {
                    contacts = await result.Content.ReadAsAsync<IList<Contact>>();
                }
            }

            return contacts;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;

                //HTTP POST
                var postTask = await client.PostAsJsonAsync<Contact>("contact", contact);
            }

            return contact;
        }

        public async Task<Contact> UpdateContact(int id, Contact contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;

                //HTTP POST
                var putTask = await client.PutAsJsonAsync<Contact>("contact/" + id.ToString(), contact);
            }

            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;

                //HTTP POST
                var deleteTask = await client.DeleteAsync("contact/" + id.ToString());
            }

            return true;
        }
    }
}
