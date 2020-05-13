using MyContacts.Model;
using MyContacts.Repository;
using System;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class FrmCreate : Form
    {
        private Contact _contact;
        private bool _isEditMode = false;
        private IContactRepository _repository;

        public FrmCreate(IContactRepository repository)
        {
            _repository = repository;
            Initialize();
        }

        public FrmCreate(Contact contact, IContactRepository repository)
        {
            Initialize();
            _contact = contact;
            _repository = repository;
            _isEditMode = true;
        }

        private void Initialize()
        {
            InitializeComponent();
        }

        private void FrmCreate_Load(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                Text = "افزودن شخص جدید";
            }
            else
            {
                Text = "ویرایش شخص";
                txtName.Text = _contact.Name;
                txtFamilyname.Text = _contact.FamilyName;
                txtAge.Text = _contact.Age.ToString();
                txtEmail.Text = _contact.Email;
                txtAddress.Text = _contact.Address;
                txtPhoneNumber.Text = _contact.TelNumber;
            }
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

            if (txtPhoneNumber.Text != "") return true;
            MessageBox.Show("لطفا شماره موبایل خود را وارد کنید.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_isEditMode)
                {
                    _repository.Update(_contact.Id, txtName.Text, txtFamilyname.Text, txtPhoneNumber.Text, txtEmail.Text, txtAddress.Text, (int)txtAge.Value);
                    DialogResult = DialogResult.OK;
                }
                else
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
}
