using EHI.ContactsInvetory.BusinessLayer;
using EHI.ContactsInvetory.DataAccess.Repository;
using EHI.ContactsInvetory.Dto;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EHI.ContactsInvetory.Tests
{
    public class ContactBusinessLayerTest
    {
        [Fact]
        public async Task GetContactById()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.GetContact(1)).ReturnsAsync(new Contact() { FirstName = "Jon", LastName="Doe", Email = "jon.doe@gmail.com", PhoneNumber="111111111"});
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.GetContact(1);
            Assert.True("Jon" == result.FirstName);
        }

        [Fact]
        public async Task GetContactByIdNoData()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.GetContact(1)).ReturnsAsync(default(Contact));
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.GetContact(1);
            Assert.True(default(Contact) == result);
        }

        [Fact]
        public async Task GetContacts()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.GetContacts()).ReturnsAsync(new List<Contact>(){ new Contact() { FirstName = "Jon", LastName = "Doe", Email = "jon.doe@gmail.com", PhoneNumber = "111111111" }});
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.GetContacts();
            Assert.True("Jon" == ((List<Contact>)result)[0].FirstName);
        }

        [Fact]
        public async Task GetContactsNoData()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.GetContacts()).ReturnsAsync(default(List<Contact>));
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.GetContacts();
            Assert.True(result == default(List<Contact>));
        }

        [Fact]
        public async Task AddContact()
        {
            var contact = new Contact() { FirstName = "Jon", LastName = "Doe", Email = "jon.doe@gmail.com", PhoneNumber = "111111111" };
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.AddContact(contact)).ReturnsAsync(contact);
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.AddContact(contact);
            Assert.True("Jon" == result.FirstName);
        }

        [Fact]
        public async Task UpdateContact()
        {
            var contact = new Contact() { FirstName = "Jon1", LastName = "Doe", Email = "jon.doe@gmail.com", PhoneNumber = "111111111" };
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.UpdateContact(contact)).ReturnsAsync(contact);
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.UpdateContact(contact);
            Assert.True("Jon1" == result.FirstName);
        }

        [Fact]
        public async Task DeleteContact()
        {
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.DeleteContact(1)).ReturnsAsync(true);
            var cbl = new ContactBusinessLayer(mock.Object);
            var result = await cbl.DeleteContact(1);
            Assert.True(result);
        }
    }
}
