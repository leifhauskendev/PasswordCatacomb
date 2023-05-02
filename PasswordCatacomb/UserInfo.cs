using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace PasswordCatacomb
{
    public class UserInfo : AESInfo
    {
        #region Private Fields
        private string _username;
        private byte[] _salt;
        #endregion

        #region Public Properties
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public byte[] Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }
        #endregion

        #region Methods
        public static string HashStringWithArgon2(string passwordPlainText, byte[] salt)
        {
            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(passwordPlainText))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024 // 1 GB
            };

            var hash = argon2.GetBytes(32);

            return Convert.ToBase64String(hash);
        }
        #endregion
    }
}
