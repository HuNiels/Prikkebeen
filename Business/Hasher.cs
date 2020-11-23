using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Acupunctuur.Business
{
    public class Hasher
    {
        private const int SaltLength = 32;

        public byte[] Hash(string password)
        {
            byte[] salt = new byte[SaltLength];
            RNGCryptoServiceProvider.Create().GetBytes(salt);
            return HashWithSalt(password, salt);
        }

        private byte[] HashWithSalt(string password, byte[] salt)
        {
            HashAlgorithm alg = new SHA256Managed();
            byte[] passwordBytes = UnicodeEncoding.Unicode.GetBytes(password);

            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

            saltedPassword = CopyBytes(saltedPassword, passwordBytes, 0);
            saltedPassword = CopyBytes(saltedPassword, salt, passwordBytes.Length);

            byte[] hashedPassword = alg.ComputeHash(saltedPassword);
            byte[] hashedPasswordAndSalt = new byte[hashedPassword.Length + salt.Length];
            hashedPasswordAndSalt = CopyBytes(hashedPasswordAndSalt, hashedPassword, 0);
            hashedPasswordAndSalt = CopyBytes(hashedPasswordAndSalt, salt, hashedPassword.Length);

            return hashedPasswordAndSalt;
        }

        private byte[] GetSaltFromHashedPw(byte[] hashedPw)
        {
            byte[] salt = new byte[SaltLength];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = hashedPw[i + hashedPw.Length - SaltLength];
            }
            return salt;
        }

        public bool CompareHash(string password, byte[] savedPw)
        {
            byte[] salt = GetSaltFromHashedPw(savedPw);
            byte[] hashedPw = HashWithSalt(password, salt);
            return hashedPw.SequenceEqual(savedPw);
        }

        private static byte[] CopyBytes(byte[] bytes1, byte[] bytes2, int startIndex)
        {
            byte[] result = new byte[bytes1.Length];

            // Deep copy
            for (int i = 0; i < bytes1.Length; i++)
            {
                result[i] = bytes1[i];
            }

            for (int i = 0; i < bytes2.Length; i++)
            {
                result[i + startIndex] = bytes2[i];
            }

            return result;
        }
    }
}
