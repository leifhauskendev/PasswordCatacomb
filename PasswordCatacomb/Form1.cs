using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace PasswordCatacomb
{
    public partial class Form1 : Form
    {
        public const string constuser = "leifj";

        private PasswordInfo _passwordInfo = new PasswordInfo();

        public PasswordInfo PasswordInfo
        {
            get { return _passwordInfo; }
            set { _passwordInfo = value; }
        }

        public Form1()
        {
            InitializeComponent();
            PasswordInfo.User = constuser;
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
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                if (radioButton == addRadioButton)
                {
                    enterButton.Text= "Add";
                }
                else if (radioButton == updateRadioButton)
                {
                    enterButton.Text = "Update";
                }
                else if (radioButton == retrieveRadioButton)
                {
                    enterButton.Text = "Retrieve";
                }
                else if (radioButton == deleteRadioButton)
                {
                    enterButton.Text = "Delete";
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (enterButton.Text== "Add") 
            {
                PasswordInfo.AESKey = AesHelper.GenerateKey(PasswordInfo.PasswordString);
                PasswordInfo.AESIV = AesHelper.GenerateIV();
                PasswordInfo.EncryptedPassword = AesHelper.EncryptStringToBytes(PasswordInfo.PasswordString, PasswordInfo.AESKey, PasswordInfo.AESIV);
                PasswordDA.CreateRecord(PasswordInfo);
            }
            if (enterButton.Text == "Update")
            {
                PasswordInfo.AESKey = AesHelper.GenerateKey(PasswordInfo.PasswordString);
                PasswordInfo.AESIV = AesHelper.GenerateIV();
                PasswordInfo.EncryptedPassword = AesHelper.EncryptStringToBytes(PasswordInfo.PasswordString, PasswordInfo.AESKey, PasswordInfo.AESIV);
                PasswordDA.UpdateRecord(PasswordInfo);
            }
            if (enterButton.Text == "Retrieve")
            {
                PasswordInfo = PasswordDA.ReadRecord(PasswordInfo.User, PasswordInfo.PasswordName);
                PasswordInfo.PasswordString = AesHelper.DecryptStringFromBytes(PasswordInfo.EncryptedPassword, PasswordInfo.AESKey, PasswordInfo.AESIV);
                passwordStringTextBox.Text = PasswordInfo.PasswordString;
            }
            if (enterButton.Text == "Delete")
            {
                PasswordDA.DeleteRecord(PasswordInfo.User, PasswordInfo.PasswordName);
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
    }
}
