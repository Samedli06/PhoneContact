using PhoneContact.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PhoneContact.Controller;

namespace PhoneContact.Services
{
    public class ContactFileService
    {
        private readonly string filePath = "contacts.json"; 

        public void ResetFile()
        {
            try
            {
                File.WriteAllText(filePath, "[]");
                Console.WriteLine("Contacts file has been reset.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting file: {ex.Message}");
            }
        }
        public void SaveToFile(List<Contact> contacts)
        {
            try
            {
                
                string jsonString = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });

            
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Contacts saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving contacts to file: {ex.Message}");
            }
        }

 
        public List<Contact> LoadFromFile()
        {
           
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found, creating a new one.");
                return new List<Contact>();
            }

            try
            {
                
                string jsonString = File.ReadAllText(filePath);

             
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    Console.WriteLine("File is empty, initializing with an empty array.");
                    return new List<Contact>();
                }

               
                return JsonSerializer.Deserialize<List<Contact>>(jsonString) ?? new List<Contact>();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON error reading file: {jsonEx.Message}");
                return new List<Contact>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new List<Contact>(); 
            }
        }
    }
}
