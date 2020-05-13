using System.Collections.Generic;
using System.Linq;
using MyContacts.Model;

namespace MyContacts.Repository
{
    internal class SqlServerContactRepository : IContactRepository
    {

        private readonly ContactContext _context;

        // private readonly string _connectionString = "data Source=. ; initial catalog=Contact_DB; Integrated Security= true";
        public SqlServerContactRepository(ContactContext contact)
        {
            _context = contact;

        }

        public bool Delete(int contactId)
        {
            try
            {
                var contact = _context.Contacts.First(x => x.Id == contactId);
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        

        public bool Insert(string name, string familyName, string telNumber, string email, string address, int age)
        {

            try
            {
                var contact = new Contact
                {
                    Name = name,
                    FamilyName = familyName,
                    Age = age,
                    Email = email,
                    Address = address,
                    TelNumber = telNumber
                };

                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return true;
            }
            catch
            {

                throw;
            }
        }

        public List<Contact> SelectAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact SelectRow(int contactId)
        {
            var contact = _context.Contacts.First(x => x.Id == contactId);

            return contact;
        }

        public bool Update(int contactId, string name, string familyName, string telNumber, string email,
            string address, int age)
        {
            try
            {
                var contact = _context.Contacts.First(x => x.Id == contactId);
                contact.Name = name;
                contact.FamilyName = familyName;
                contact.Age = age;
                contact.Address = address;
                contact.Email = email;
                contact.TelNumber = telNumber;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
