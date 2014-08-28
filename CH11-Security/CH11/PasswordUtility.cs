using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace CH11.Helpers
{
    public class PasswordUtility
    {
        public static bool PasswordLength(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            else
            {
                if (0 - Convert.ToInt32(Regex.IsMatch(password, "[a-z]")) -
                       Convert.ToInt32(Regex.IsMatch(password, "[A-Z]")) -
                       Convert.ToInt32(Regex.IsMatch(password, @"\d")) -
                       Convert.ToInt32(Regex.IsMatch(password, ".{10,}")) <= -2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string AESEncryptor(string plainText, byte[] Key, byte[] IV)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(plainText);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            string encryptedString = Convert.ToBase64String(aes.CreateEncryptor(Key, IV).TransformFinalBlock(data, 0, data.Length));
            return encryptedString;
        }

        public static string AESDecryptor(string encryptedString, byte[] Key, byte[] IV)
        {
            byte[] data = Convert.FromBase64String(encryptedString);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            string decryptedString = ASCIIEncoding.ASCII.GetString(aes.CreateDecryptor(Key, IV).TransformFinalBlock(data, 0, data.Length));
            return decryptedString;
        }

        public static string SHA256Encryptor(string plainText)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(plainText);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] result = sha256.ComputeHash(data);

            return Convert.ToBase64String(result);
        }

        public static string SHA512Encryptor(string plainText)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(plainText);
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] result = sha512.ComputeHash(data);

            return Convert.ToBase64String(result);
        }

        public static string GuidwithPassword(Guid guid, string plainText)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(plainText + guid.ToString());
            byte[] result;
            SHA512Managed sha = new SHA512Managed();
            result = sha.ComputeHash(data);
            return Convert.ToBase64String(result);
        }


    }
}