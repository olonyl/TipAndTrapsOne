using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class CompressingInMemoryStreams
    {
        [TestMethod]
        public void Example()
        {
            const string originalString = @"Lorem Ipsum is simply dummy text of the printing and typesetting 
                                            industry. Lorem Ipsum has been the industry's standard dummy text 
                                            ever since the 1500s, when an unknown printer took a galley of type 
                                            and scrambled it to make";

            var originalBytes = Encoding.ASCII.GetBytes(originalString);

            //Compress
            var compressedBytes = Compress(originalBytes);

            var originalSize = originalBytes.Length;
            var comrpessedSize = compressedBytes.Length;
            var sizeDifference = originalSize - comrpessedSize;

            //Decompress
            var decompressedBytes = Decompress(compressedBytes);
            var decompressedString = Encoding.ASCII.GetString(decompressedBytes);

            var isSameString = originalString == decompressedString;

        }

        private byte[] Decompress(byte[] compressedBytes)
        {
            var memoryStreamOfCompressedBytes = new MemoryStream(compressedBytes);

            using (var decompressIntoMs = new MemoryStream())
            using (var gzs = new GZipStream(memoryStreamOfCompressedBytes, CompressionMode.Decompress))
            {
                gzs.CopyTo(decompressIntoMs);

                var decompressedBytes = decompressIntoMs.ToArray();

                return decompressedBytes;
            }
        }

        private byte[] Compress(byte[] originalBytes)
        {
            var compressIntoMs = new MemoryStream();

            using (var gzs = new GZipStream(compressIntoMs, CompressionMode.Compress))
            {
                gzs.Write(originalBytes, 0, originalBytes.Length);
            }

            var compressedBytes = compressIntoMs.ToArray();

            return compressedBytes;
        }
    }
}
