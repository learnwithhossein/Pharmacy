using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace MyContacts.Repository
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int ContactID);
        bool Insert(String name, String familyname, String TelNumber, String Email, String Address, int age);
        bool Update(int ContactID, String name, String familyname, String TelNumber, String Email, String Address, int age);
        bool Delet(int ContactID);
    }
}
