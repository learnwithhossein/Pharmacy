using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyContacts.Repository;
using MyContacts;



namespace MyContacts
{
    public partial class Form2 : Form
    {
        IContactRepository Repository;
        public Form2()
        {
            InitializeComponent();
            Repository = new ContactRepository();
        }

        private void FormAddorEdit_Load(object sender, EventArgs e)
        {
            this.Text = "افزودن شخص جدید";
        }
        bool ValidateInput()
        {
            

            if(txtName.Text=="")
            {
                
          
                MessageBox.Show("لطفا نام خود را وارد کنید.","هشدار", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if(txtFamilyname.Text=="")
            {
                MessageBox.Show("لطفا نام خانوادگی خود را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن خود را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPhoneNumber.Text == "")
            {
                MessageBox.Show("لطفا شماره موبایل خود را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool isSucces = Repository.Insert(txtName.Text, txtFamilyname.Text, txtPhoneNumber.Text, txtEmail.Text, txtAddress.Text,(int)txtAge.Value);
                if(isSucces==true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات ناموفق.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
