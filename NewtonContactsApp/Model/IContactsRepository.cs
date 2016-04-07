using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public interface IContactsRepository
    {
        IList<Contact> GetAll();

        Contact Get(int index);

        int Create(Contact contact);

        void Update(Contact contact);

        void Delete(int index);

        void SaveChanges();
    }
}
