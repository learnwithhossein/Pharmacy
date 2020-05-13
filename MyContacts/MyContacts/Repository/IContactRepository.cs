using MyContacts.Model;
using System.Collections.Generic;


namespace MyContacts.Repository
{
    public interface IContactRepository
    {
        List<Contact> SelectAll();
        Contact SelectRow(int contactId);

        bool Insert(string name, string familyName, string telNumber, string email, string address, int age);
        bool Update(int contactId, string name, string familyName, string telNumber, string email, string address, int age);
        bool Delete(int contactId);
    }
}
