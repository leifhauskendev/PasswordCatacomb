using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCatacomb
{
    public partial class LoginForm : Form
    {
        private bool _valid = false;

        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void createAccountLabel_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.ShowDialog();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo = UserDA.ReadRecord(usernameTextBox.Text);

            string hashedPassword = UserInfo.HashStringWithArgon2(passwordTextBox.Text, userInfo.Salt);

            userInfo.PasswordString = AesHelper.DecryptStringFromBytes(userInfo.EncryptedPassword, userInfo.AESKey, userInfo.AESIV);

            if (hashedPassword == userInfo.PasswordString) 
            {
                Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
