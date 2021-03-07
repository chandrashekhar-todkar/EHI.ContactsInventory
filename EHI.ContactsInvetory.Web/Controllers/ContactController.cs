using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHI.ContactsInvetory.Dto;
using EHI.ContactsInvetory.Web.Models;
using Microsoft.Extensions.Logging;

namespace EHI.ContactsInvetory.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger _logger;
        private readonly ContactModel _contactModel;

        public ContactController(ILogger<ContactController> logger, ContactModel contactModel)
        {
            _logger = logger;
            _contactModel = contactModel;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _contactModel.GetContacts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var contact = await _contactModel.GetContact(id.Value);
                if (contact == null)
                {
                    return NotFound();
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Contact contact)
        {
            try
            {
                await _contactModel.AddContact(contact);
                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var contact = await _contactModel.GetContact(id.Value);
                if (contact == null)
                {
                    return NotFound();
                }
                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber")] Contact contact)
        {
            try
            {
                if (id != contact.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    await _contactModel.UpdateContact(id, contact);

                    return RedirectToAction(nameof(Index));
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var contact = await _contactModel.GetContact(id.Value);
                if (contact == null)
                {
                    return NotFound();
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _contactModel.DeleteContact(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ ex.Message } {(ex.InnerException != null ? ex.InnerException.Message : string.Empty)} {ex.StackTrace}");
                return RedirectToAction(nameof(Error));
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
