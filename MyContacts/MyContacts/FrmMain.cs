using MyContacts.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyContacts.Model;

namespace MyContacts
{
    public partial class FrmMain : Form
    {
        readonly IContactRepository _repository;

        public FrmMain()
        {
            InitializeComponent();
            var contact = new ContactContext();
            _repository = new SqlServerContactRepository(contact);
        }

        private void FrmCreate(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void BindGrid()
        {
           
           dgContact.DataSource = _repository.SelectAll();


        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgContact.Refresh();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var frm = new FrmCreate();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgContact.CurrentRow != null)
            {
                var nme = dgContact.CurrentRow.Cells[2].Value.ToString();
                var fml = dgContact.CurrentRow.Cells[3].Value.ToString();
                var fullName = nme + " " + fml;
                if (MessageBox.Show($"  آیا از حذف  {fullName}  مطمئن هستید؟ ", "توجه", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    int contactID = int.Parse(dgContact.CurrentRow.Cells[1].Value.ToString());
                    _repository.Delete(contactID);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را از لیست انتخاب کنید");


            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContact.CurrentRow != null)
            {
                int contactId = int.Parse(dgContact.CurrentRow.Cells[1].Value.ToString());
                var contact = _repository.SelectRow(contactId);
                FrmCreate frm = new FrmCreate(contact);
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // BindGrid();
                    var list = dgContact.DataSource as List<Contact>;
                    var updated = _repository.SelectRow(contactId);
                    list.Remove(contact);
                    list.Add(updated);

                }
            }
        }
    }
}


