using MyContacts.Repository;
using System;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class FrmMain : Form
    {
        readonly IContactRepository _repository;

        public FrmMain()
        {
            InitializeComponent();

            _repository = new SqlServerContactRepository();
        }

        private void FrmCreate(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            var data = _repository.SelectAll();
            dgContact.DataSource = new BindingSource(data, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var frm = new FrmCreate(_repository);
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
                    var contactId = int.Parse(dgContact.CurrentRow.Cells[1].Value.ToString());
                    _repository.Delete(contactId);
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
                var contactId = int.Parse(dgContact.CurrentRow.Cells[1].Value.ToString());
                var contact = _repository.SelectRow(contactId);
                var frm = new FrmCreate(contact, _repository);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }
    }
}


