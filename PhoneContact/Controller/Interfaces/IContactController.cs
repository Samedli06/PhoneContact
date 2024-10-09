using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Controller.Interfaces
{
    public interface IContactController
    {
        public void ShowAllContacts();

        public void AddContact();

        public void EditContact();

        public void Search();

        public void DeleteContact() ;



    }
}
