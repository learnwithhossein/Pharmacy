using MyContacts.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyContacts.Repository
{
    internal class SqlServerContactRepository : IContactRepository
    {
        public bool Delete(int contactId)
        {
            try
            {
                var context = new ContactContext();

                var contact = context.Contacts.First(x => x.Id == contactId);
                context.Contacts.Remove(contact);
                context.SaveChanges();
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

                var context = new ContactContext();

                context.Contacts.Add(contact);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Contact> SelectAll()
        {
            var context = new ContactContext();
            var data = context.Contacts.ToList();

            return data;
        }

        public Contact SelectRow(int contactId)
        {
            var context = new ContactContext();

            var contact = context.Contacts.First(x => x.Id == contactId);

            return contact;
        }

        public bool Update(int contactId, string name, string familyName, string telNumber, string email,
            string address, int age)
        {
            try
            {
                var context = new ContactContext();

                var contact = context.Contacts.First(x => x.Id == contactId);
                contact.Name = name;
                contact.FamilyName = familyName;
                contact.Age = age;
                contact.Address = address;
                contact.Email = email;
                contact.TelNumber = telNumber;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
