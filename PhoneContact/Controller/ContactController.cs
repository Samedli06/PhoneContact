using PhoneContact.Controller.Interfaces;
using PhoneContact.Model;
using PhoneContact.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Controller
{

    public class ContactController : IContactController
    {
        public List<Contact> contacts = new List<Contact>();
        private ContactFileService fileService;

        public ContactController()
        {
            fileService = new ContactFileService();
            contacts = fileService.LoadFromFile(); 
        }

        public void ResetContacts()
        {
            fileService.ResetFile();
            contacts.Clear(); 
        }

        ValidFunctions validFunctions = new ValidFunctions();

        
        public void AddContact()
        {
            Console.Clear();
            string name = validFunctions.GetValidName();
            string surname = validFunctions.GetValidSurname();
            string number = validFunctions.GetValidPhoneNumber();

            int newId = contacts.Any() ? contacts.Max(c => c.ID) + 1 : 1;

            Contact contact = new Contact(name, surname, number);
            contacts.Add(contact);
            fileService.SaveToFile(contacts);

        }

        public void ShowAllContacts()
        {
            Console.Clear ();
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"ID: {contact.ID}, Name: {contact.name}, Surname: {contact.surname}, Phone: {contact.phoneNumber}");
                Console.WriteLine("-------");
            }
        }

        public void Search()
        {
            Console.Clear();
            Console.WriteLine("Search for:\n1.Name\n2.Surname\n3.Phone Number");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string Name = validFunctions.GetValidName();
                    foreach (Contact contact in contacts)
                    {
                        if (Name.Equals(contact.name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"ID: {contact.ID}, Name: {contact.name}, Surname: {contact.surname}, Phone: {contact.phoneNumber}");
                            Console.WriteLine("-------");
                        }
                    }
                    break;
                case "2":
                    string SurName = validFunctions.GetValidSurname();
                    foreach (Contact contact in contacts)
                    {
                        if (SurName.Equals(contact.surname, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"ID: {contact.ID}, Name: {contact.name}, Surname: {contact.surname}, Phone: {contact.phoneNumber}");
                            Console.WriteLine("-------");
                        }
                    }
                    break;
                case "3":
                    string number = validFunctions.GetValidPhoneNumber();
                    foreach (Contact contact in contacts)
                    {
                        if (number.Equals(contact.phoneNumber))
                        {
                            Console.WriteLine($"ID: {contact.ID}, Name: {contact.name}, Surname: {contact.surname}, Phone: {contact.phoneNumber}");
                            Console.WriteLine("-------");
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void DeleteContact()
        {
            Console.Clear ();
            ShowAllContacts();
            Console.Write("Enter Id which you want delete: ");
            int choosenID = Convert.ToInt32(Console.ReadLine());
            Contact contactToDelete = contacts.FirstOrDefault(c => c.ID == choosenID);


            foreach (Contact contact in contacts)
            {
                if (contact.ID == choosenID)
                {
                    contacts.RemoveAt(choosenID);
                    break;
                }
            }
        }

        public void EditContact()
        {
            Console.Clear ();
            ShowAllContacts();
            Console.Write("Enter Id of the contact you want to edit: ");
            int chosenID = Convert.ToInt32(Console.ReadLine());

            Contact contactToEdit = contacts.FirstOrDefault(c => c.ID == chosenID);

            if (contactToEdit == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("What do you want to edit:\n1.Name\n2.Surname\n3.Number");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactToEdit.name = validFunctions.GetValidName();
                    break;
                case "2":;
                    contactToEdit.surname = validFunctions.GetValidSurname();
                    break;
                case "3":
                    contactToEdit.phoneNumber = validFunctions.GetValidPhoneNumber();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            fileService.SaveToFile(contacts); 
            Console.WriteLine("Contact updated successfully.");
        }
    }
}
