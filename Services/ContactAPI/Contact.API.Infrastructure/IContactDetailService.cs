using Contact.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Infrastructure
{
    public interface IContactDetailService
    {
        public Task<Guid> Create(ContactDetailModel contact);

        public Task<bool> Delete(Guid ContactDetailId);

        public Task<IEnumerable<ContactDetailModel>> Get();

        public Task<ContactDetailModel> Get(Guid ContactDetailId);
    }
}
