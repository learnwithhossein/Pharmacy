using System.Data;

namespace MyContacts.Repository
{
    internal class SquliteContactRepository : IContactRepository
    {
        public bool Delete(int contactId)
        {
            
        }

        public bool Insert(string name, string familyName, string telNumber, string email, string address, int age)
        {
            throw new System.NotImplementedException();
        }

        public DataTable SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public DataTable SelectRow(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(int contactId, string name, string familyName, string telNumber, string email, string address, int age)
        {
            throw new System.NotImplementedException();
        }
    }
}
