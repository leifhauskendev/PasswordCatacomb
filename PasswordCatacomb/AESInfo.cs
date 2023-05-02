using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCatacomb
{
    public class AESInfo
    {
        #region Private Fields
        private string _passwordString;
        private byte[] _encyrptedPassword;
        private byte[] _aesKey;
        private byte[] _aesIV;
        #endregion

        #region Public Properties
        public string PasswordString
        {
            get { return _passwordString; }
            set { _passwordString = value; }
        }

        public byte[] EncryptedPassword
        {
            get { return _encyrptedPassword; }
            set { _encyrptedPassword = value; }
        }

        public byte[] AESKey
        {
            get { return _aesKey; }
            set { _aesKey = value; }
        }

        public byte[] AESIV
        {
            get { return _aesIV; }
            set { _aesIV = value; }
        }
        #endregion

        #region Methods
        public byte[] GetEncryptedPassword()
        {
            byte[] encryptedPassword = null;
            if (!string.IsNullOrEmpty(_passwordString))
            {
                encryptedPassword = AesHelper.EncryptStringToBytes(_passwordString, _aesKey, _aesIV);
            }
            return encryptedPassword;
        }

        public string GetDecryptedPassword(byte[] encryptedPassword)
        {
            string decryptedPassword = null;
            if (encryptedPassword != null)
            {
                decryptedPassword = AesHelper.DecryptStringFromBytes(encryptedPassword, _aesKey, _aesIV);
            }
            return decryptedPassword;
        }

        public static byte[] GenerateAESKey(string password)
        {
            return AesHelper.GenerateKey(password);
        }

        public static byte[] GenerateAESIV()
        {
            return AesHelper.GenerateIV();
        }
        #endregion
    }
}
