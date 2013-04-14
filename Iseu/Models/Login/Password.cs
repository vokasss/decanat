using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Iseu.Models
{
    public sealed class Password
    {
        private const int SaltLength = 6;

        private readonly string _salt;
        private readonly string _hash;

        
        private Password(string salt, string hash)
        {
            _salt = salt;
            _hash = hash;
        }

        public static Password Empty
        {
            get { return new Password(String.Empty, String.Empty); }
        }

        public string Salt
        {
            get { return _salt; }
        }

        public string Hash
        {
            get { return _hash; }
        }
        
        private static string CreateSalt()
        {
            var r = CreateRandomBytes(SaltLength);
            return Convert.ToBase64String(r);
        }

        private static byte[] CreateRandomBytes(int length)
        {
            var r = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(r);
            return r;
        }

        public static string CalculateHash(string salt, string password)
        {
            var data = ToByteArray(salt + password);
            var hash = CalculateHash(data);
            return Convert.ToBase64String(hash);
        }

        private static byte[] CalculateHash(byte[] data)
        {
            return new SHA1CryptoServiceProvider().ComputeHash(data);
        }

        private static byte[] ToByteArray(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static Password Create(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new Password(string.Empty, string.Empty);
            }

            var salt = CreateSalt();
            var hash = CalculateHash(salt, password);

            return new Password(salt, hash);
        }

        public static Password Create(string salt, string hash)
        {
            return new Password(salt, hash);
        }

        public bool IsEmpty
        {
            get { return string.IsNullOrEmpty(Hash); }
        }
       
        public bool Verify(string password)
        {
            var h = CalculateHash(_salt, password);
            return String.Equals(_hash, h, StringComparison.Ordinal);
        }

       
    }
}