using System;
using System.Data;

namespace MyContacts.Repository
{
  internal  class SqliteContactRepository:IContactRepository
    {
        public object SelectAll()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectRow(int contactId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string familyName, string telNumber, string email, string address, int age)
        {
            throw new NotImplementedException();
        }

        public bool Update(int contactId, string name, string familyName, string telNumber, string email, string address, int age)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int contactId)
        {
            throw new NotImplementedException();
        }
    }
}
