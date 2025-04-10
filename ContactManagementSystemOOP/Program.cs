using System;

namespace ContactManagementOOP
{
    // Define the Contact class
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public Contact(string name, string phoneNumber, string email, string dateOfBirth)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Phone: {PhoneNumber}, Email: {Email}, DOB: {DateOfBirth}";
        }
    }

    public class Program
    {
        static int maxContacts = 100;
        static Contact[] contacts = new Contact[maxContacts]; // Static array
        static int contactCount = 0;

        public static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nContact Management System");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Find a Contact");
                Console.WriteLine("4. Edit a Contact");
                Console.WriteLine("5. Remove a Contact");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddContact(); break;
                    case "2": DisplayContacts(); break;
                    case "3": FindContact(); break;
                    case "4": EditContact(); break;
                    case "5": RemoveContact(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid option. Try again."); break;
                }
            }
            Console.WriteLine("Goodbye!");
        }

        public static void AddContact()
        {
            if (contactCount < maxContacts)
            {
                Console.Write("Enter contact name: ");
                string name = Console.ReadLine();
                Console.Write("Enter phone number: ");
                string phone = Console.ReadLine();
                Console.Write("Enter email address: ");
                string email = Console.ReadLine();
                Console.Write("Enter D.O.B: ");
                string dob = Console.ReadLine();

                contacts[contactCount] = new Contact(name, phone, email, dob);
                contactCount++;
                Console.WriteLine("Contact added!");
            }
            else
            {
                Console.WriteLine("Contact list is full!");
            }
        }

        public static void DisplayContacts()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to display.");
                return;
            }

            Console.WriteLine("Contacts:");
            for (int i = 0; i < contactCount; i++)
            {
                Console.WriteLine($"{i + 1}. {contacts[i]}");
            }
        }

        public static void FindContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to find.");
                return;
            }

            Console.Write("Enter the name to search for: ");
            string searchName = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < contactCount; i++)
            {
                if (contacts[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found: {contacts[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Contact Not Found.");
            }
        }

        public static void EditContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to edit.");
                return;
            }

            Console.Write("Enter the name of the contact to edit: ");
            string nameToEdit = Console.ReadLine();
            int indexToEdit = -1;

            for (int i = 0; i < contactCount; i++)
            {
                if (contacts[i].Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase))
                {
                    indexToEdit = i;
                    break;
                }
            }

            if (indexToEdit != -1)
            {
                Console.Write("Enter new phone number: ");
                string newPhoneNumber = Console.ReadLine();
                contacts[indexToEdit].PhoneNumber = newPhoneNumber;

                Console.Write("Enter new email address: ");
                string newEmail = Console.ReadLine();
                contacts[indexToEdit].Email = newEmail;

                Console.Write("Enter new D.O.B: ");
                string newDob = Console.ReadLine();
                contacts[indexToEdit].DateOfBirth = newDob;

                Console.WriteLine("Contact updated.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public static void RemoveContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to remove.");
                return;
            }

            Console.Write("Enter the name of the contact to remove: ");
            string nameToRemove = Console.ReadLine();
            int indexToRemove = -1;

            for (int i = 0; i < contactCount; i++)
            {
                if (contacts[i].Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                for (int i = indexToRemove; i < contactCount - 1; i++)
                {
                    contacts[i] = contacts[i + 1];
                }
                contacts[contactCount - 1] = null;
                contactCount--;
                Console.WriteLine("Contact removed.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}