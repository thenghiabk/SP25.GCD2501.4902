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
        private string Name { get; set; }

        // phone
        private string Phone { get; set; }
        // email
        private string Email { get; set; }
        // dob
        private string Dob { get; set; }

        // constructor
        public Contact(string name, string phone, string email, string dob) {
            Name = name;
            Phone = phone;
            Email = email;
            Dob = dob;
        }

        // helpers
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Dob: " + Dob);
        }
    }

    class ClosedContact : Contact
    {
        // status
        private string Status { get; set; }

        public ClosedContact(string name, string phone, string email, string dob, string status) : base(name, phone, email, dob)
        {
            Status = status;
        }

        // helpers
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Status: " + Status);
        }
    }

    class ImportantContact : Contact
    {
        // company
        private string Company { get; set; }
        // job title
        private string JobTitle { get; set; }
        public ImportantContact(string name, string phone, string email, string dob, string company, string jobTitle) : base(name, phone, email, dob)
        {
            Company = company;
            JobTitle = jobTitle;
        }

        // helpers
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Company: " + Company);
            Console.WriteLine("Job Title: " + JobTitle);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Contact john = new Contact("John Doe", "123-456-7890", "jdoe@me.com", "01/01/2000");

            //Console.WriteLine("Name: " + john.Name);
            //Console.WriteLine("Phone: " + john.Phone);
            //Console.WriteLine("Email: " + john.Email);
            //Console.WriteLine("Dob: " + john.Dob);

            john.DisplayInfo();

            Contact david = new Contact("David Smith", "123-456-7892", "david@gmail.com", "10/09/2002");

            //Console.WriteLine("Name: " + david.Name);
            //Console.WriteLine("Phone: " + david.Phone);
            //Console.WriteLine("Email: " + david.Email);
            //Console.WriteLine("Dob: " + david.Dob);

            david.DisplayInfo();

            // Lucy: Name, Phone, Email, Dob, Status
            ClosedContact lucy = new ClosedContact("Lucy", "123-456-7893", "lucy@me.com", "01/01/2000", "Closed");

            // Ben: Name, Phone, Email, Dob, Company, JobTitle
            ImportantContact ben = new ImportantContact("Ben", "123-456-7894", "ben@me.com", "01/01/2000", "Google", "Software Engineer");


            lucy.DisplayInfo(); // inheritance -> overriding

            ben.DisplayInfo(); // inheritance -> overriding


            // Array to store contact information
            Contact[] contacts = new Contact[100]; // polymorphism + abstraction
            contacts[0] = john;
            contacts[1] = david;
            contacts[2] = lucy;
            contacts[3] = ben;

            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] != null)
                {
                    Console.WriteLine("Contact " + (i + 1) + ":");
                    contacts[i].DisplayInfo(); // polymorphism
                    Console.WriteLine();
                }
            }




        }
    }
}
