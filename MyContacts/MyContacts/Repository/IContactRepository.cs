using System.Collections.Generic;
using MyContacts.Model;

namespace MyContacts.Repository
{
    internal interface IContactRepository
    {
        List<Contact> SelectAll();
        Contact SelectRow(int contactId);
        bool Insert(string name, string familyName, string telNumber, string email, string address, int age);
        bool Update(int contactId, string name, string familyName, string telNumber, string email, string address, int age);
        bool Delete(int contactId);
    }
}
