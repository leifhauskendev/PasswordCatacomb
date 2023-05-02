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
        #region Private Fields
        private bool _valid = false;
        #endregion

        #region Public Properties
        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
        #endregion

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void createAccountLabel_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.ShowDialog();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Please enter both a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            UserInfo userInfo = new UserInfo();
            userInfo = UserDA.ReadRecord(usernameTextBox.Text);

            if (userInfo.Username != null)
            {
                string hashedPassword = UserInfo.HashStringWithArgon2(passwordTextBox.Text, userInfo.Salt);

                userInfo.PasswordString = AesHelper.DecryptStringFromBytes(userInfo.EncryptedPassword, userInfo.AESKey, userInfo.AESIV);

                if (hashedPassword == userInfo.PasswordString)
                {
                    Hide();
                    Form1 form1 = new Form1(userInfo.Username);
                    form1.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Password is incorrect, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username is incorrect, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
