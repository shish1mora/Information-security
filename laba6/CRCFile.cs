using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class CRCFile
    {
        public string CRC32 { get; set; }

        public string FileName { get; set; }

        public static string CalculateCRC(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            using (IncrementalHash hashAlgorithm = IncrementalHash.CreateHash(HashAlgorithmName.SHA256))
            {
                int bytesRead;
                byte[] buffer = new byte[4096];
                
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    hashAlgorithm.AppendData(buffer, 0, bytesRead);
                }

                byte[] hashBytes = hashAlgorithm.GetHashAndReset();

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
