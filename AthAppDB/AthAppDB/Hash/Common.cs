using System;
using System.Security.Cryptography;

namespace WebApplicationAthenA.Hash
{
    public class Common
    {
        public static Byte[] GetRandomsalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] Salt = new byte[length];
            random.GetNonZeroBytes(Salt);
            return Salt;
        }
        public static byte[] SaltHashPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] PlainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < salt.Length; i++)
                PlainTextWithSaltBytes[i] = password[i];
            for (int i = 0; i < salt.Length; i++)
                PlainTextWithSaltBytes[password.Length + i] = salt[i];
            return algorithm.ComputeHash(PlainTextWithSaltBytes);



        }
    }
}