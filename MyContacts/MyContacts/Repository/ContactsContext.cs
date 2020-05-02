using System.Data.Entity;
using MyContacts.Model;

namespace MyContacts.Repository
{
    public class ContactsContext : DbContext
    {
        private static readonly string _connectionString = "data Source=. ; initial catalog=Contact_DB; Integrated Security= true";

        public ContactsContext(): base(_connectionString) { }

        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
