using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Support
{
    public static class DataProtectionExtensions
    {
        //public static byte[] ENTROPY = { 0x20, 0x00, 0x01, 0x12 };
        //public static string Protect(this string clearText, string optionalEntropy = null, DataProtectionScope scope = DataProtectionScope.LocalMachine)
        //{
        //    if (clearText == null)
        //        throw new ArgumentNullException("clearText");
        //    byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
        //    byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
        //        ? null
        //        : Encoding.UTF8.GetBytes(optionalEntropy);
        //    byte[] encryptedBytes = ProtectedData.Protect(clearBytes, ENTROPY, scope);
        //    return Convert.ToBase64String(encryptedBytes);
        //}

        //public static string Unprotect(this string encryptedText,string optionalEntropy = null,DataProtectionScope scope = DataProtectionScope.LocalMachine)
        //{
        //    if (encryptedText == null)
        //        throw new ArgumentNullException("encryptedText");
        //    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        //    byte[] entropyBytes = string.IsNullOrEmpty(optionalEntropy)
        //        ? null
        //        : Encoding.UTF8.GetBytes(optionalEntropy);
        //    byte[] clearBytes = ProtectedData.Unprotect(encryptedBytes, ENTROPY, scope);
        //    return Encoding.UTF8.GetString(clearBytes);
        //}
        
        public static string Protect(string str)
        {
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.ASCII.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }

        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }
        
    //     public static string Protect(string data, string password)
    //{
    //    if(String.IsNullOrEmpty(data))
    //        throw new ArgumentException("No data given");
    //    if(String.IsNullOrEmpty(password))
    //        throw new ArgumentException("No password given");

    //    // setup the encryption algorithm
    //    Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(password, 8);
    //    Rijndael aes = Rijndael.Create();
    //    aes.IV = keyGenerator.GetBytes(aes.BlockSize / 8);
    //    aes.Key = keyGenerator.GetBytes(aes.KeySize / 8);

    //    // encrypt the data
    //    byte[] rawData = Encoding.Unicode.GetBytes(data);
    //    using(MemoryStream memoryStream = new MemoryStream())
    //    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
    //    {
    //        memoryStream.Write(keyGenerator.Salt, 0, keyGenerator.Salt.Length);
    //        cryptoStream.Write(rawData, 0, rawData.Length);
    //        cryptoStream.Close();

    //        byte[] encrypted = memoryStream.ToArray();
    //        return Encoding.Unicode.GetString(encrypted);
    //    }
    //}

    //public static string Unprotect(string data, string password)
    //{
    //    if(String.IsNullOrEmpty(data))
    //        throw new ArgumentException("No data given");
    //    if(String.IsNullOrEmpty(password))
    //        throw new ArgumentException("No password given");

    //    byte[] rawData = Encoding.Unicode.GetBytes(data);
    //    if(rawData.Length < 8)
    //        throw new ArgumentException("Invalid input data");
        
    //    // setup the decryption algorithm
    //    byte[] salt = new byte[8];
    //    for(int i = 0; i < salt.Length; i++)
    //        salt[i] = rawData[i];

    //    Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(password, salt);
    //    Rijndael aes = Rijndael.Create();
    //    aes.IV = keyGenerator.GetBytes(aes.BlockSize / 8);
    //    aes.Key = keyGenerator.GetBytes(aes.KeySize / 8);

    //    // decrypt the data
    //    using(MemoryStream memoryStream = new MemoryStream())
    //    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
    //    {
    //        cryptoStream.Write(rawData, 8, rawData.Length - 8);
    //        cryptoStream.Close();

    //        byte[] decrypted = memoryStream.ToArray();
    //        return Encoding.Unicode.GetString(decrypted);
    //    }
    

    }
}
