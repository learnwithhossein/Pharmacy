using System.Collections.Generic;
using System.Linq;
using MyContacts.Model;

namespace MyContacts.Repository
{
    internal class SqlServerContactRepository : IContactRepository
    {
        private readonly ContactsContext _context;

        public SqlServerContactRepository(ContactsContext context)
        {
            _context = context;
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
                    Address = address,
                    Age = age,
                    Email = email,
                    FamilyName = familyName,
                    Name = name,
                    TelNumber = telNumber
                };

                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
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

        public bool Update(int contactId, string name, string familyName, string telNumber, string email, string address, int age)
        {
            try
            {
                var contact = _context.Contacts.First(x => x.Id == contactId);

                contact.Name = name;
                contact.FamilyName = familyName;
                contact.TelNumber = telNumber;
                contact.Email = email;
                contact.Address = address;
                contact.Age = age;

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
