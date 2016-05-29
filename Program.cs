using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chilcat_Castle.Classes;

namespace Chilcat_Castle
{
    class Program
    {
        public const string encryptionKey = "SYUW5RV+ROmQUNtQN9dTOB==";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to encrypt:");
            Console.WriteLine("");
            string text = Console.ReadLine();
 
            Console.WriteLine("Using encryption Key: " + encryptionKey);
            Console.WriteLine("################################");
 
            var encryptedText = ChilcatEncrypt.EncryptWithChilkat(text, encryptionKey);
            Console.WriteLine("chilkat encryption output: " + encryptedText);

            var be = new BouncyEncrypt();
            var encryptedTextBouncy = be.EncryptWithBouncyCastle(text, encryptionKey);
            Console.WriteLine("bouncyCastle encryption output: " + encryptedTextBouncy);
            
            Console.ReadLine();
        }
    }
}
