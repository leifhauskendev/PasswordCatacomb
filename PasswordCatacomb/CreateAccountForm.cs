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
    public partial class CreateAccountForm : Form
    {
        private UserInfo _userInfo = new UserInfo();

        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Passwords do not match, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserInfo.Salt = AesHelper.GenerateSalt();
            UserInfo.PasswordString = UserInfo.HashStringWithArgon2(UserInfo.PasswordString, UserInfo.Salt);

            UserInfo.AESKey = AesHelper.GenerateKey(UserInfo.PasswordString);
            UserInfo.AESIV = AesHelper.GenerateIV();
            UserInfo.EncryptedPassword = AesHelper.EncryptStringToBytes(UserInfo.PasswordString, UserInfo.AESKey, UserInfo.AESIV);
            UserDA.CreateRecord(UserInfo);
        }

        private void usernameTextBox_Leave(object sender, EventArgs e)
        {
            UserInfo.Username = usernameTextBox.Text;
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            UserInfo.PasswordString = passwordTextBox.Text;
        }
    }
}
