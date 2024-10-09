using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact
{
    public class ValidFunctions
    {
        public string GetValidName()
        {
            while (true)
            {
                Console.Write("Enter name: ");
                string input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid name (letters only).");
            }
        }

        public string GetValidSurname()
        {
            while (true)
            {
                Console.Write("Enter Surname: ");
                string input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid name (letters only).");
            }
        }

        public string GetValidPhoneNumber()
        {
            while (true) 
            {
                Console.Write("Enter phone number: ");
                string input = Console.ReadLine();

 
                if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit) && input.Length == 10)
                {
                    return input; 
                }

                Console.WriteLine("Invalid input. Please enter a valid 10-digit phone number.");
            }
        }

    }

}
