using PhoneContact.Controller;

class Program
{
    static void Main(string[] args)
    {
        ContactController contactController = new ContactController();
        bool running = true;


        while (running)
        {
            Console.WriteLine("Phone Contact Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Show All Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactController.AddContact();

                    break;
                case "2":
                    contactController.ShowAllContacts();
                    break;
                case "3":
                    contactController.Search();
                    break;
                case "4":
                    contactController.EditContact();
                    break;
                case "5":
                    contactController.DeleteContact();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
