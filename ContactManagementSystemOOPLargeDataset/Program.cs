using System;
using System.IO;

namespace ContactManagementOOP
{
    // Interface for polymorphism and abstraction
    public interface IContact
    {
        string GetDetails();
        string FirstName { get; }
        string LastName { get; }
        string PhoneNumber { get; }
        string Email { get; }
        string DateOfBirth { get; }
    }

    // Abstract base class for contacts
    public abstract class Contact : IContact
    {
        private readonly string _firstName; // Encapsulation
        private readonly string _lastName;
        private readonly string _phoneNumber;
        private readonly string _email;
        private readonly string _dateOfBirth;

        protected Contact(string firstName, string lastName, string phoneNumber, string email, string dateOfBirth)
        {
            _firstName = ValidateNonEmpty(firstName, nameof(firstName));
            _lastName = ValidateNonEmpty(lastName, nameof(lastName));
            _phoneNumber = ValidatePhone(phoneNumber);
            _email = ValidateEmail(email);
            _dateOfBirth = dateOfBirth;
        }

        // Public properties (encapsulation)
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string PhoneNumber => _phoneNumber;
        public string Email => _email;
        public string DateOfBirth => _dateOfBirth;

        // Abstract method for polymorphism
        public abstract string GetDetails();

        // Validation methods (encapsulation)
        private string ValidateNonEmpty(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} cannot be empty");
            return value;
        }

        private string ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 7)
                throw new ArgumentException("Invalid phone number");
            return phone;
        }

        private string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email address");
            return email;
        }
    }

    // BusinessContact subclass (inheritance)
    public class BusinessContact : Contact
    {
        private readonly string _company;

        public BusinessContact(string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string company)
            : base(firstName, lastName, phoneNumber, email, dateOfBirth)
        {
            _company = company ?? "";
        }

        public string Company => _company;

        public override string GetDetails() =>
            $"Business Contact: First Name: {FirstName}, Last Name: {LastName}, Phone: {PhoneNumber}, Email: {Email}, DOB: {DateOfBirth}, Company: {_company}";
    }

    // FriendContact subclass (inheritance)
    public class FriendContact : Contact
    {
        private readonly string _nickname;

        public FriendContact(string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string nickname)
            : base(firstName, lastName, phoneNumber, email, dateOfBirth)
        {
            _nickname = nickname ?? "";
        }

        public string Nickname => _nickname;

        public override string GetDetails() =>
            $"Friend Contact: First Name: {FirstName}, Last Name: {LastName}, Phone: {PhoneNumber}, Email: {Email}, DOB: {DateOfBirth}, Nickname: {_nickname}";
    }

    // FamilyContact subclass (inheritance)
    public class FamilyContact : Contact
    {
        private readonly string _relationship;

        public FamilyContact(string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string relationship)
            : base(firstName, lastName, phoneNumber, email, dateOfBirth)
        {
            _relationship = relationship ?? "";
        }

        public string Relationship => _relationship;

        public override string GetDetails() =>
            $"Family Contact: First Name: {FirstName}, Last Name: {LastName}, Phone: {PhoneNumber}, Email: {Email}, DOB: {DateOfBirth}, Relationship: {_relationship}";
    }

    // Factory class for creating contacts (Factory Pattern)
    public class ContactFactory
    {
        public IContact CreateContact(string type, string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string additionalInfo)
        {
            switch (type.ToLower())
            {
                case "business":
                    return new BusinessContact(firstName, lastName, phoneNumber, email, dateOfBirth, additionalInfo);
                case "friend":
                    return new FriendContact(firstName, lastName, phoneNumber, email, dateOfBirth, additionalInfo);
                case "family":
                    return new FamilyContact(firstName, lastName, phoneNumber, email, dateOfBirth, additionalInfo);
                default:
                    throw new ArgumentException("Invalid contact type");
            }
        }
    }

    // Interface for reading contacts (DIP)
    public interface IContactReader
    {
        IContact[] ReadContacts(string source);
    }

    // CSV reader (SRP)
    public class CSVContactReader : IContactReader
    {
        private readonly ContactFactory _factory;

        public CSVContactReader(ContactFactory factory = null)
        {
            _factory = factory ?? new ContactFactory();
        }

        public IContact[] ReadContacts(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            IContact[] contacts = new IContact[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length == 7)
                {
                    string type = parts[5].ToLower();
                    string additionalInfo = parts[6];
                    try
                    {
                        contacts[i] = _factory.CreateContact(type, parts[0], parts[1], parts[2], parts[3], parts[4], additionalInfo);
                    }
                    catch (ArgumentException)
                    {
                        // Skip invalid entries
                    }
                }
            }
            return contacts;
        }
    }

    // Interface for filtering (OCP, ISP)
    public interface IContactFilter
    {
        IContact[] Filter(IContact[] contacts);
    }

    // Filter by name (updated to use first and last name)
    public class NameFilter : IContactFilter
    {
        private readonly string _targetName;

        public NameFilter(string targetName)
        {
            _targetName = targetName;
        }

        public IContact[] Filter(IContact[] contacts)
        {
            IContact[] result = new IContact[contacts.Length];
            int index = 0;
            for (int i = 0; i < contacts.Length && contacts[i] != null; i++)
            {
                if (contacts[i].FirstName.Equals(_targetName, StringComparison.OrdinalIgnoreCase) 
                    || contacts[i].LastName.Equals(_targetName, StringComparison.OrdinalIgnoreCase))
                {
                    result[index++] = contacts[i];
                }
            }
            return result;
        }
    }

    // Filter by contact type
    public class TypeFilter : IContactFilter
    {
        private readonly string _targetType;
        public TypeFilter(string targetType) => _targetType = targetType.ToLower();

        public IContact[] Filter(IContact[] contacts)
        {
            IContact[] result = new IContact[contacts.Length];
            int index = 0;
            for (int i = 0; i < contacts.Length && contacts[i] != null; i++)
            {
                bool matches = false;
                switch (_targetType)
                {
                    case "business":
                        matches = contacts[i] is BusinessContact;
                        break;
                    case "friend":
                        matches = contacts[i] is FriendContact;
                        break;
                    case "family":
                        matches = contacts[i] is FamilyContact;
                        break;
                }
                if (matches)
                {
                    result[index++] = contacts[i];
                }
            }
            return result;
        }
    }

    // Contact manager (SRP, DIP)
    public class ContactManager
    {
        private IContact[] _contacts;
        private int _contactCount;
        private readonly IContactReader _reader;
        private readonly ContactFactory _factory;
        private readonly int _maxContacts;

        public ContactManager(IContactReader reader, ContactFactory factory = null, int maxContacts = 1000)
        {
            _reader = reader;
            _factory = factory ?? new ContactFactory();
            _maxContacts = maxContacts;
            _contacts = new IContact[maxContacts];
            _contactCount = 0;
        }

        public void LoadFromSource(string source)
        {
            _contacts = _reader.ReadContacts(source);
            for (int i = 0; i < _contacts.Length && _contacts[i] != null; i++)
            {
                _contactCount++;
            }
        }

        public void AddContact(string type, string firstName, string lastName, string phoneNumber, string email, string dateOfBirth, string additionalInfo)
        {
            if (_contactCount < _maxContacts)
            {
                IContact contact = _factory.CreateContact(type, firstName, lastName, phoneNumber, email, dateOfBirth, additionalInfo);
                _contacts[_contactCount] = contact;
                _contactCount++;
            }
        }

        public bool DeleteContact(string firstName, string lastName)
        {
            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    _contacts[i].LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    // Shift contacts to fill the gap
                    for (int j = i; j < _contactCount - 1; j++)
                    {
                        _contacts[j] = _contacts[j + 1];
                    }
                    _contacts[_contactCount - 1] = null;
                    _contactCount--;
                    return true;
                }
            }
            return false;
        }

        public bool EditContact(string oldFirstName, string oldLastName, string type, string newFirstName, string newLastName, string newPhoneNumber, string newEmail, string newDateOfBirth, string newAdditionalInfo)
        {
            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].FirstName.Equals(oldFirstName, StringComparison.OrdinalIgnoreCase) &&
                    _contacts[i].LastName.Equals(oldLastName, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IContact newContact = _factory.CreateContact(type, newFirstName, newLastName, newPhoneNumber, newEmail, newDateOfBirth, newAdditionalInfo);
                        _contacts[i] = newContact;
                        return true;
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public IContact[] FilterContacts(IContactFilter filter) => filter.Filter(_contacts);

        public IContact[] GetAllContacts() => _contacts;

        public int GetContactCount() => _contactCount;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ContactFactory factory = new ContactFactory();
            IContactReader reader = new CSVContactReader(factory);
            ContactManager manager = new ContactManager(reader, factory);
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nContact Management System");
                Console.WriteLine("1. Load Contacts from CSV");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Filter by Name");
                Console.WriteLine("4. Filter by Type");
                Console.WriteLine("5. Display Contacts");
                Console.WriteLine("6. Delete Contact");
                Console.WriteLine("7. Edit Contact");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter CSV file path: ");
                        string path = Console.ReadLine();
                        try
                        {
                            manager.LoadFromSource(path);
                            Console.WriteLine("Contacts loaded.");
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Error loading file: {ex.Message}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter contact type (business/friend/family): ");
                        string type = Console.ReadLine().ToLower();
                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter DOB: ");
                        string dob = Console.ReadLine();
                        Console.Write("Enter additional info (company/nickname/relationship): ");
                        string additionalInfo = Console.ReadLine();
                        try
                        {
                            manager.AddContact(type, firstName, lastName, phone, email, dob, additionalInfo);
                            Console.WriteLine("Contact added.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        Console.Write("Enter name to filter: ");
                        string filterName = Console.ReadLine();
                        IContactFilter nameFilter = new NameFilter(filterName);
                        IContact[] nameFiltered = manager.FilterContacts(nameFilter);
                        foreach (var c in nameFiltered)
                        {
                            if (c != null) Console.WriteLine(c.GetDetails());
                        }
                        break;
                    case "4":
                        Console.Write("Enter type to filter (business/friend/family): ");
                        string filterType = Console.ReadLine();
                        IContactFilter typeFilter = new TypeFilter(filterType);
                        IContact[] typeFiltered = manager.FilterContacts(typeFilter);
                        foreach (var c in typeFiltered)
                        {
                            if (c != null) Console.WriteLine(c.GetDetails());
                        }
                        break;
                    case "5":
                        IContact[] contacts = manager.GetAllContacts();
                        for (int i = 0; i < manager.GetContactCount(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {contacts[i].GetDetails()}");
                        }
                        break;
                    case "6":
                        Console.Write("Enter first name of contact to delete: ");
                        string firstNameToDelete = Console.ReadLine();
                        Console.Write("Enter last name of contact to delete: ");
                        string lastNameToDelete = Console.ReadLine();
                        if (manager.DeleteContact(firstNameToDelete, lastNameToDelete))
                        {
                            Console.WriteLine("Contact deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        break;
                    case "7":
                        Console.Write("Enter first name of contact to edit: ");
                        string oldFirstName = Console.ReadLine();
                        Console.Write("Enter last name of contact to edit: ");
                        string oldLastName = Console.ReadLine();
                        Console.Write("Enter new contact type (business/friend/family): ");
                        string newType = Console.ReadLine().ToLower();
                        Console.Write("Enter new first name: ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("Enter new last name: ");
                        string newLastName = Console.ReadLine();
                        Console.Write("Enter new phone: ");
                        string newPhone = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter new DOB: ");
                        string newDob = Console.ReadLine();
                        Console.Write("Enter new additional info (company/nickname/relationship): ");
                        string newAdditionalInfo = Console.ReadLine();
                        try
                        {
                            if (manager.EditContact(oldFirstName, oldLastName, newType, newFirstName, newLastName, newPhone, newEmail, newDob, newAdditionalInfo))
                            {
                                Console.WriteLine("Contact updated.");
                            }
                            else
                            {
                                Console.WriteLine("Contact not found or invalid data.");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}