using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace PasswordCatacomb
{
    public partial class Form1 : Form
    {
        private PasswordInfo _passwordInfo = new PasswordInfo();
        private List<string> _passwordNamesForUser = new List<string>();

        public PasswordInfo PasswordInfo
        {
            get { return _passwordInfo; }
            set { _passwordInfo = value; }
        }

        public List<string> PasswordNamesForUser
        {
            get { return _passwordNamesForUser; }
            set { _passwordNamesForUser = value; }
        }

        public Form1(string user)
        {
            InitializeComponent();
            PasswordInfo.User = user;
            PasswordNamesForUser = PasswordDA.GetPasswordNamesForUser(user);
            passwordNameComboBox.DataSource = PasswordNamesForUser;
            EventLogger.AddLog("Log In", user);
        }

        //private void passwordNameTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    PasswordInfo.PasswordName = passwordStringTextBox.Text;
        //}

        //private void passwordStringTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    PasswordInfo.PasswordString = passwordStringTextBox.Text;
        //}

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            passwordNameTextBox.Text = string.Empty;
            passwordStringTextBox.Text = string.Empty;
            passwordNameComboBox.Text = string.Empty;
            autoGenerateCheckBox.Checked = false;

            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                if (radioButton == addRadioButton)
                {
                    enterButton.Text= "Add";
                    passwordStringTextBox.ReadOnly = false;
                    passwordNameComboBox.Visible = false;
                    autoGenerateCheckBox.Visible = true;
                    autoGenerateLabel.Visible = true;
                }
                else if (radioButton == updateRadioButton)
                {
                    enterButton.Text = "Update";
                    passwordStringTextBox.ReadOnly = false;
                    passwordNameComboBox.Visible = true;
                    passwordNameTextBox.Text = string.Empty;
                    autoGenerateCheckBox.Visible = true;
                    autoGenerateLabel.Visible = true;
                }
                else if (radioButton == retrieveRadioButton)
                {
                    enterButton.Text = "Retrieve";
                    passwordStringTextBox.ReadOnly= true;
                    passwordNameComboBox.Visible = true;
                    passwordNameTextBox.Text = string.Empty;
                    autoGenerateCheckBox.Visible = false;
                    autoGenerateLabel.Visible = false;
                }
                else if (radioButton == deleteRadioButton)
                {
                    enterButton.Text = "Delete";
                    passwordStringTextBox.ReadOnly = true;
                    passwordNameComboBox.Visible = true;
                    passwordNameTextBox.Text = string.Empty;
                    autoGenerateCheckBox.Visible = false;
                    autoGenerateLabel.Visible = false;
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (enterButton.Text == "Add")
            {
                if ((string.IsNullOrEmpty(passwordNameTextBox.Text) && string.IsNullOrEmpty(passwordNameComboBox.Text)) || string.IsNullOrEmpty(passwordStringTextBox.Text))
                {
                    MessageBox.Show("Please enter both the password name and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PasswordInfo.AESKey = AesHelper.GenerateKey(PasswordInfo.PasswordString);
                PasswordInfo.AESIV = AesHelper.GenerateIV();
                PasswordInfo.EncryptedPassword = AesHelper.EncryptStringToBytes(PasswordInfo.PasswordString, PasswordInfo.AESKey, PasswordInfo.AESIV);
                PasswordDA.CreateRecord(PasswordInfo);
                passwordNameComboBox.DataSource = PasswordDA.GetPasswordNamesForUser(PasswordInfo.User);
                passwordNameComboBox.Refresh();
            }
            else if (enterButton.Text == "Update")
            {
                if ((string.IsNullOrEmpty(passwordNameTextBox.Text) && string.IsNullOrEmpty(passwordNameComboBox.Text)) || string.IsNullOrEmpty(passwordStringTextBox.Text))
                {
                    MessageBox.Show("Please enter both the password name and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PasswordInfo.AESKey = AesHelper.GenerateKey(PasswordInfo.PasswordString);
                PasswordInfo.AESIV = AesHelper.GenerateIV();
                PasswordInfo.EncryptedPassword = AesHelper.EncryptStringToBytes(PasswordInfo.PasswordString, PasswordInfo.AESKey, PasswordInfo.AESIV);
                PasswordDA.UpdateRecord(PasswordInfo);
            }
            else if (enterButton.Text == "Retrieve")
            {
                if (string.IsNullOrEmpty(passwordNameTextBox.Text) && string.IsNullOrEmpty(passwordNameComboBox.Text))
                {
                    MessageBox.Show("Please enter the password name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PasswordInfo = PasswordDA.ReadRecord(PasswordInfo.User, PasswordInfo.PasswordName);
                if (PasswordInfo.User != null)
                {
                    PasswordInfo.PasswordString = AesHelper.DecryptStringFromBytes(PasswordInfo.EncryptedPassword, PasswordInfo.AESKey, PasswordInfo.AESIV);
                    passwordStringTextBox.Text = PasswordInfo.PasswordString;
                }
                else
                {
                    MessageBox.Show("Password with that name does not exist, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (enterButton.Text == "Delete")
            {
                if (string.IsNullOrEmpty(passwordNameTextBox.Text) && string.IsNullOrEmpty(passwordNameComboBox.Text))
                {
                    MessageBox.Show("Please enter the password name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PasswordDA.DeleteRecord(PasswordInfo.User, PasswordInfo.PasswordName);
                passwordNameComboBox.DataSource = PasswordDA.GetPasswordNamesForUser(PasswordInfo.User);
                passwordNameComboBox.Refresh();
            }

            if (enterButton.Text != "Retrieve")
            {
                passwordNameTextBox.Text = string.Empty;
                passwordStringTextBox.Text = string.Empty;
                passwordNameComboBox.Text = string.Empty;
            }
        }


        private void passwordNameTextBox_Leave(object sender, EventArgs e)
        {
            PasswordInfo.PasswordName = passwordNameTextBox.Text;
        }

        private void passwordStringTextBox_Leave(object sender, EventArgs e)
        {
            PasswordInfo.PasswordString = passwordStringTextBox.Text;
        }

        private void passwordNameComboBox_Leave(object sender, EventArgs e)
        {
            PasswordInfo.PasswordName = passwordNameComboBox.Text;
        }

        public static string GenerateStrongPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=-{}[]\\|:;<>,.?/";
            int length = 15;

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];
                crypto.GetBytes(data);

                StringBuilder result = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    int index = data[i] % chars.Length;
                    result.Append(chars[index]);
                }

                return result.ToString();
            }
        }

        private void autoGenerateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoGenerateCheckBox.Checked)
            {
                PasswordInfo.PasswordString = passwordStringTextBox.Text = GenerateStrongPassword();
            }
            else
            {
                PasswordInfo.PasswordString = passwordStringTextBox.Text = string.Empty;
            }
        }
    }
}
