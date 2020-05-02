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

            var context = new ContactsContext();
            _repository = new SqlServerContactRepository(context);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BinGrid();

        }

        private void BinGrid()
        {
            dgContact.DataSource = _repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BinGrid();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var frm = new FrmCreate();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BinGrid();

            }
        }
    }
}
