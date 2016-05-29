using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Engines;

namespace Chilcat_Castle.Classes
{
    class BouncyEncrypt
    {
        public string EncryptWithBouncyCastle(
            string token,
            string encryptionKey
            )
        {
            IBlockCipher blowFishCipher = new BlowfishEngine();

            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(blowFishCipher);

            cipher.Init(true, new KeyParameter(Base64.Decode(encryptionKey)));

            var encoder = new ASCIIEncoding();
            byte[] tokenBytes = encoder.GetBytes(token);

            byte[] encryptedTokenBytes = cipher.DoFinal(tokenBytes);
            var encryptedToken = Convert.ToBase64String(encryptedTokenBytes);

            return encryptedToken;
        }
    }
}