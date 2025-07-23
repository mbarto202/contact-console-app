namespace ContactManager
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        // Constructor to enforce required fields
        public Contact(string name, string email, string phone, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} | {Email} | {Phone} | DOB: {DateOfBirth.ToShortDateString()}";
        }
    }
}
