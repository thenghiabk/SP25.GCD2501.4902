﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementSystemBasic
{
    public class Program
    {
        // Maximum number of contacts we can store (you can change this)
        static int maxContacts = 100;

        // Our arrays to store contact information
        static string[] names = new string[maxContacts];
        static string[] phoneNumbers = new string[maxContacts];
        static string[] emails = new string[maxContacts];
        static string[] dobs = new string[maxContacts];

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
                if (names[i].Equals(nameToEdit, StringComparison.OrdinalIgnoreCase))
                {
                    indexToEdit = i;
                    break; // Exit the loop once we find it
                }
            }

            if (indexToEdit != -1)
            {
                Console.Write("Enter new phone number: ");
                string newPhoneNumber = Console.ReadLine();
                if (!String.IsNullOrEmpty(newPhoneNumber))
                {
                    phoneNumbers[indexToEdit] = newPhoneNumber;
                }
                    

                Console.Write("Enter new email address: ");
                string newEmail = Console.ReadLine();
                if (!String.IsNullOrEmpty(newEmail))
                {
                    emails[indexToEdit] = newEmail;
                }
 
                Console.Write("Enter new D.O.B: ");
                string newDob = Console.ReadLine();
                if (!String.IsNullOrEmpty(newDob))
                {
                    dobs[indexToEdit] = newDob;
                }

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
                names[contactCount] = Console.ReadLine();

                Console.Write("Enter phone number: ");
                phoneNumbers[contactCount] = Console.ReadLine();

                Console.Write("Enter email address: ");
                emails[contactCount] = Console.ReadLine();

                Console.Write("Enter D.O.B: ");
                dobs[contactCount] = Console.ReadLine();

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
            for (int i = 0; i < contactCount; i++)
            {
                Console.WriteLine($"  Name: {names[i]}, Phone: {phoneNumbers[i]}, Email: {emails[i]}, D.O.B: {dobs[i]}");
            }
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

            for (int i = 0; i < contactCount; i++)
            {
                //Use .Equals and ignore cases when comparing
                if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"  Name: {names[i]}, Phone: {phoneNumbers[i]}, Email: {emails[i]}, D.O.B: {dobs[i]}");
                    
                    found = true;
                }
            }

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

            for (int i = 0; i < contactCount; i++)
            {
                if (names[i].Equals(nameToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    indexToRemove = i;
                    break; // Exit the loop once we find it
                }
            }

            if (indexToRemove != -1)
            {
                // Shift elements to fill the gap
                for (int i = indexToRemove; i < contactCount - 1; i++)
                {
                    names[i] = names[i + 1];
                    phoneNumbers[i] = phoneNumbers[i + 1];
                    emails[i] = emails[i + 1];
                    dobs[i] = dobs[i + 1];
                }

                // "Clear" the last element (not strictly necessary, but good practice)
                names[contactCount - 1] = null;
                phoneNumbers[contactCount - 1] = null;
                emails[contactCount - 1] = null;
                dobs[contactCount - 1] = null;

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
