using System;
using ContactManager;

class Program
{
    static void Main(string[] args)
    {
        var service = new ContactService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nContact Manager Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Search Contacts");
            Console.WriteLine("4. Remove Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddContact(service);
                    break;
                case "2":
                    ViewAllContacts(service);
                    break;
                case "3":
                    SearchContacts(service);
                    break;
                case "4":
                    RemoveContact(service);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddContact(ContactService service)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Date of Birth (yyyy-mm-dd): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());

        var contact = new Contact(name, email, phone, dob);
        service.AddContact(contact);

        Console.WriteLine("Contact added successfully!");
    }

    static void ViewAllContacts(ContactService service)
    {
        var contacts = service.GetAllContacts();
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    static void SearchContacts(ContactService service)
    {
        Console.Write("Enter keyword to search: ");
        string keyword = Console.ReadLine();

        var results = service.SearchContacts(keyword);
        if (results.Count == 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {
            foreach (var contact in results)
            {
                Console.WriteLine(contact);
            }
        }
    }

    static void RemoveContact(ContactService service)
    {
        Console.Write("Enter Contact ID to remove: ");
        string idInput = Console.ReadLine();

        if (Guid.TryParse(idInput, out Guid id))
        {
            bool removed = service.RemoveContact(id);
            Console.WriteLine(removed ? "Contact removed." : "Contact not found.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}
