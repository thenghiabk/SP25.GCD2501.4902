using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding
{
    class Contact
    {
        // name
        public string Name { get; set; }
        // phone
        public string Phone { get; set; }
        // email
        public string Email { get; set; }
        // dob
        public string Dob { get; set; }

        // constructor
        public Contact(string name, string phone, string email, string dob) {
            Name = name;
            Phone = phone;
            Email = email;
            Dob = dob;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Contact john = new Contact("John Doe", "123-456-7890", "jdoe@me.com", "01/01/2000");

            Console.WriteLine("Name: " + john.Name);
            Console.WriteLine("Phone: " + john.Phone);
            Console.WriteLine("Email: " + john.Email);
            Console.WriteLine("Dob: " + john.Dob);

            Contact david = new Contact("David Smith", "123-456-7892", "david@gmail.com", "10/09/2002");

            Console.WriteLine("Name: " + david.Name);
            Console.WriteLine("Phone: " + david.Phone);
            Console.WriteLine("Email: " + david.Email);
            Console.WriteLine("Dob: " + david.Dob);

            john.Email = "john@fpt.com";

            Console.WriteLine("Name: " + john.Name);
            Console.WriteLine("Phone: " + john.Phone);
            Console.WriteLine("Email: " + john.Email);
            Console.WriteLine("Dob: " + john.Dob);

            Contact[] contacts = new Contact[100];
            contacts[0] = john;
            contacts[1] = david;
            contacts[2] = new Contact("Lucy Smith", "123-456-7893", "lucy@gmail.com", "03/04/2005");
            
            // Edit Lucy's email
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].Name == "Lucy Smith") // ?
                {
                    contacts[i].Email = "lucy@kenh14.vn"; // ?
                    break;
                }
            }

        }
    }
}
