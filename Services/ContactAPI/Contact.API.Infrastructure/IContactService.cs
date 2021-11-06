using Contact.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure
{
    public interface IContactService
    {
        public Task<Guid> Create(ContactModel contact);

        public Task<bool> Delete(Guid ContactId);

        public Task<IEnumerable<ContactModel>> Get();

        public Task<ContactModel> Get(Guid ContactId);
        public Task<bool> Validate(Guid ContactId);
    }
}
