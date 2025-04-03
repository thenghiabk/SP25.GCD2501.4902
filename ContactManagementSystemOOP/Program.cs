using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementOOP
{
    // TODO: Contact class to hold contact information

    public class Program
    {
        // Maximum number of contacts we can store (you can change this)
        static int maxContacts = 100;


        // TODO: Create arrays to store contact information
        Contact contacts = new Contact[maxContacts];    

        // Keep track of how many contacts we have
        static int contactCount = 0;

        public static void Main(string[] args)
        {
            // The main loop of our program
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
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        DisplayContacts();
                        break;
                    case "3":
                        FindContact();
                        break;
                    case "4":
                        EditContact();
                        break;
                    case "5":
                        RemoveContact();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static void EditContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to edit.");
                return;
            }

            Console.Write("Enter the name of the contact to edit: ");
            string nameToEdit = Console.ReadLine();

            int indexToEdit = -1; // -1 means we haven't found it yet

            for (int i = 0; i < contactCount; i++)
            {
                // TODO: Check if this contact has the name we're looking for

            }

            if (indexToEdit != -1)
            {
                Console.Write("Enter new phone number: ");
                string newPhoneNumber = Console.ReadLine();
                
                // TODO: Update the phone number


                Console.Write("Enter new email address: ");
                string newEmail = Console.ReadLine();

                // TODO: Update the email address

                Console.Write("Enter new D.O.B: ");
                string newDob = Console.ReadLine();
                
                // TODO: Update the D.O.B

                Console.WriteLine("Contact updated.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

        }
        static void AddContact()
        {
            if (contactCount < maxContacts)
            {
                Console.Write("Enter contact name: ");
                

                Console.Write("Enter phone number: ");
                

                Console.Write("Enter email address: ");
                

                Console.Write("Enter D.O.B: ");

                // TODO: Create a new contact and add it to the arrays

                contactCount++; // count = count + 1

                Console.WriteLine("Contact added!");
            }
            else
            {
                Console.WriteLine("Contact list is full!");
            }
        }
        static void DisplayContacts()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to display.");
                return;
            }

            Console.WriteLine("Contacts:");
            
            // TODO: Loop through the arrays and display each contact
        }

        static void FindContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to find.");
                return;
            }

            Console.Write("Enter the name to search for: ");
            string searchName = Console.ReadLine();

            bool found = false;

            // TODO: Loop through the arrays and search for the contact

            if (!found)
            {
                Console.WriteLine("Contact Not Found.");
            }
        }

        static void RemoveContact()
        {
            if (contactCount == 0)
            {
                Console.WriteLine("No contacts to remove.");
                return;
            }

            Console.Write("Enter the name of the contact to remove: ");
            string nameToRemove = Console.ReadLine();

            int indexToRemove = -1; // -1 means we haven't found it yet

            // TODO: Loop through the arrays and search for the contact

            if (indexToRemove != -1)
            {
                // Shift elements to fill the gap
                for (int i = indexToRemove; i < contactCount - 1; i++)
                {
                    // TODO: Shift elements in the arrays
                }

                // "Clear" the last element (not strictly necessary, but good practice)
                
                // TODO: Clear the last element

                contactCount--; // Decrement the count

                Console.WriteLine("Contact removed.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
