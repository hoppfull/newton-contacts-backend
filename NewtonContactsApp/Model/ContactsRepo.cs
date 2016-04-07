using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public class ContactsRepo : IContactsRepository
    {
        public void Init()
        {

        }

        public int Create(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public Contact Get(int index)
        {
            throw new NotImplementedException();
        }

        public IList<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
