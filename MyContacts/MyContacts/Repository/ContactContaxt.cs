using System.Data.Entity;
using MyContacts.Model;

namespace MyContacts.Repository
{
    internal class ContactContext:DbContext
    {
        private static readonly string ConnectionString = "data Source=. ; initial catalog=Contact_DB; Integrated Security= true";
        public ContactContext():base(ConnectionString){}
        public DbSet<Contact> Contacts { get; set; }

    }
}
