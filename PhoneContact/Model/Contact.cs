using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneContact.Model
{
    public class Contact
    {

        public Contact() { }

        static int Id = 0;

        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }

       
        public Contact(string Name , string Surname , string number)
        {
            Id++;
            ID = Id;
            name = Name;
            surname = Surname;
            phoneNumber = number;
        }

    }
}
