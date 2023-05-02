using PasswordCatacomb;
using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordInfo : AESInfo
{
    #region Private Fields
    private string _user;
    private string _passwordName;
    #endregion

    #region Public Properties
    public string User
    {
        get { return _user; }
        set { _user = value; }
    }

    public string PasswordName
    {
        get { return _passwordName; }
        set { _passwordName = value; }
    }
    #endregion
}
