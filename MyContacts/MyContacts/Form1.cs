using MyContacts.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactRepository Repository;
        public Form1()
        {
            InitializeComponent();
            Repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BinGrid();

        }

        private void BinGrid()
        {
            dgContact.AutoGenerateColumns = false;
            dgContact.DataSource = Repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BinGrid();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                BinGrid();

            }
        }
    }
}
