using Contact.API.Data;
using Contact.API.Infrastructure;
using Contact.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactContext _dbContext;
        public ContactService(ContactContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Create(ContactModel contact)
        {
            await _dbContext.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact.ContactId;
        }

        public async Task<bool> Delete(Guid ContactId)
        {
            try
            {
                var contact = await Get(ContactId);
                _dbContext.Contacts.Remove(contact);
                var num = await _dbContext.SaveChangesAsync();
                return num > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ContactModel>> Get()
        {
            return await _dbContext.Contacts.Include(c => c.ContactDetail).ToListAsync();
        }

        public async Task<ContactModel> Get(Guid ContactId)
        {
            return await _dbContext.Contacts.Where(c => c.ContactId == ContactId).Include(c => c.ContactDetail).FirstOrDefaultAsync();
        }

        public async Task<bool> Validate(Guid ContactId)
        {
            return await _dbContext.Contacts.Where(c => c.ContactId == ContactId).CountAsync() > 0;
        }
    }
}
