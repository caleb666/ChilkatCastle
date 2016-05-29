using Chilkat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilcat_Castle.Classes
{
    class ChilcatEncrypt
    {
        public static string EncryptWithChilkat(
            string token,
            string encryptionKey,
            string chilkatUnlockCode = "NEPCORCrypt_rhULxqvYRMGN",
            string cryptAlgorythm = "blowfish2",
            string cipherMode = "ecb",
            int keyLength = 128,
            string encodingMode = "base64")
        {
            using (var crypt = new Crypt2())
            {
                bool success = crypt.UnlockComponent(chilkatUnlockCode);

                if (success != true)
                    throw new NotSupportedException(crypt.LastErrorText);

                crypt.CryptAlgorithm = cryptAlgorythm;
                crypt.CipherMode = cipherMode;
                crypt.KeyLength = keyLength;
                crypt.EncodingMode = encodingMode;
                crypt.SetEncodedKey(encryptionKey, encodingMode);

                //  Encrypt the token
                var encoded = crypt.EncryptStringENC(token);

                return encoded;
            }
        }
    }
}
