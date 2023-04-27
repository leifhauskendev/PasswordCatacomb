using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordInfo
{
    private string _user;
    private string _passwordName;
    private string _passwordString;
    private byte[] _encyrptedPassword;
    private byte[] _aesKey;
    private byte[] _aesIV;

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

    //public PasswordInfo(string passwordName, string passwordString, byte[] encyrptedPassword, byte[] aesKey, byte[] aesIV)
    //{
    //    this._passwordName = passwordName;
    //    this._passwordString = passwordString;
    //    this._encyrptedPassword = encyrptedPassword;
    //    this._aesKey = aesKey;
    //    this._aesIV = aesIV;
    //}

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
}

