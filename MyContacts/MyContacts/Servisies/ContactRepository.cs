using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MyContacts;
using System.Data;
using MyContacts.Repository;

namespace MyContacts
{
    class ContactRepository : IContactRepository
    {
        private string connectionString = "data Source=. ; initial catalog=Contact_DB; Integrated Security= true";
        public bool Delet(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string name, string familyname, string TelNumber, string Email, string Address,int age)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
               
                String query = "Insert Into ContactList (name,familyname,age,Address,Email,TelNumber) values (@name,@familyname,@age,@Address,@Email,@TelNumber);";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@familyname", familyname);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@TelNumber",TelNumber);
                connection.Open();
                command.ExecuteNonQuery();
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SelectAll()
        {
            String query = "select * from ContactList ";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Update(int ContactID, string name, string familyname, string TelNumber, string Email, string Address, int age)
        {
            throw new NotImplementedException();
        }
    }
}
