using System;
using System.Windows.Forms;
using MyContacts.Repository;


namespace MyContacts
{
    public partial class FrmCreate : Form
    {
        readonly IContactRepository _repository;

        public FrmCreate()
        {
            InitializeComponent();

            var context = new ContactsContext();
            _repository = new SqlServerContactRepository(context);
        }

        private void FrmCreate_Load(object sender, EventArgs e)
        {
            Text = "افزودن شخص جدید";
        }

        private bool ValidateInput()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام خود را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamilyname.Text == "")
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
                var isSuccess = _repository.Insert(txtName.Text, txtFamilyname.Text, txtPhoneNumber.Text, txtEmail.Text, txtAddress.Text, (int)txtAge.Value);
                if (isSuccess)
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
