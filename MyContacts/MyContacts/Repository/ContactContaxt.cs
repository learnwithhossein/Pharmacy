using System.Data.Entity;
using MyContacts.Model;

namespace MyContacts.Repository
{
    internal class ContactContext:DbContext
    {
        private static readonly string _connectionString = "data Source=. ; initial catalog=Contact_DB; Integrated Security= true";
        public ContactContext():base(_connectionString){}
        public DbSet<Contact> Contacts { get; set; }

    }
}
