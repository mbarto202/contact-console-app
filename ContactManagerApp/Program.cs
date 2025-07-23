using System;
using ContactManager;

class Program
{
    static void Main(string[] args)
    {
        var service = new ContactService();

        // Add a test contact
        var contact = new Contact(
            name: "Jane Doe",
            email: "jane@example.com",
            phone: "555-6789",
            dateOfBirth: new DateTime(1990, 5, 15)
        );

        service.AddContact(contact);

        // Display all contacts
        var contacts = service.GetAllContacts();
        foreach (var c in contacts)
        {
            Console.WriteLine(c);
        }
    }
}
