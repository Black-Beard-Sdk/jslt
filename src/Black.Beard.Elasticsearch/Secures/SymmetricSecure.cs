using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Bb.Extensions.Secures
{


    public class SymmetricSecure
    {

        public static SymmetricSecure Get(SymmetricKindEnum kind)
        {

            SymmetricAlgorithm algorithm = null;

            switch (kind)
            {

                case SymmetricKindEnum.DES:
                    algorithm = new DESCryptoServiceProvider();
                        break;

                case SymmetricKindEnum.RC2:
                    algorithm = new RC2CryptoServiceProvider();
                    break;

                case SymmetricKindEnum.Rijndael:
                    algorithm = new RijndaelManaged();
                    break;

                case SymmetricKindEnum.AesManaged:
                    algorithm = new AesCryptoServiceProvider();
                    break;

                case SymmetricKindEnum.TripleDES:
                    algorithm = new TripleDESCryptoServiceProvider();
                    break;

                default:
                    break;
            }

            return new SymmetricSecure(algorithm);

        }

        private SymmetricSecure(SymmetricAlgorithm algorithm)
        {
            this._algorithm = algorithm;
        }

        public string GetKeys()
        {
            var length = 1 + _key.Length + _iv.Length;
            var resultByte = new byte[length];
            resultByte[0] = (byte)_key.Length;
            _key.CopyTo(resultByte, 1);
            _iv.CopyTo(resultByte, _key.Length + 1);
            var result = Convert.ToBase64String(resultByte);
            return result;
        }

        public void InitializeFromSalt(string password)
        {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes); // Hash the password with SHA256
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            var _keySize = 256;
            var _blockSize = 128;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            _key = key.GetBytes(_keySize / 8);
            _iv = key.GetBytes(_blockSize / 8);

            this._algorithm.Mode = CipherMode.CBC;

        }

        public void InitializeFromKey(string keys)
        {

            var k = Convert.FromBase64String(keys);
            var l1 = k[0];

            _key = new byte[l1];
            for (int i = 0; i < l1; i++)
                _key[i] = k[i + 1];

            _iv = new byte[k.Length - l1 - 1];
            var l = k.Length - l1 - 1;
            for (int i = 0; i < l; i++)
                _iv[i] = k[i + 1 + l1];

        }

        public void InitializeFromKeys(string key, string iv)
        {
            _key = Convert.FromBase64String(key);
            _iv = Convert.FromBase64String(iv);
        }

        public void Initialize()
        {
            _key = this._algorithm.Key;
            _iv = this._algorithm.IV;
        }

        public string Decrypt(string cryptedText)
        {
            var cryptedTextAsByte = Convert.FromBase64String(cryptedText);
            return Decrypt(cryptedTextAsByte);
        }

        public string Decrypt(byte[] cryptedTextAsByte)
        {
            var decryptor = this._algorithm.CreateDecryptor(_key, _iv);
            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);
            return Encoding.Default.GetString(decryptedTextAsByte);
        }

        public string Encrypt(string text)
        {
            var encryptor = this._algorithm.CreateEncryptor(_key, _iv);
            byte[] textAsByte = Encoding.Default.GetBytes(text);
            byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(textAsByte, 0, textAsByte.Length);
            return Convert.ToBase64String(cryptedTextAsByte);
        }

        private readonly SymmetricAlgorithm _algorithm;
        private byte[] _key;
        private byte[] _iv;

    }

}
