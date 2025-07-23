using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ContactManager
{
    public class ContactService
    {
        private readonly string _filePath = "contacts.json";
        private List<Contact> _contacts;

        public ContactService()
        {
            _contacts = LoadContacts();
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            SaveContacts();
        }

        public bool RemoveContact(Guid id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                SaveContacts();
                return true;
            }
            return false;
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public List<Contact> SearchContacts(string keyword)
        {
            return _contacts.Where(c =>
                c.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void SaveContacts()
        {
            var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private List<Contact> LoadContacts()
        {
            if (!File.Exists(_filePath))
                return new List<Contact>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
