using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Compression;

namespace CompilerInferredGenericMethodtypes
{
    [TestClass]
    public class WorkingWithZipFiles
    {
        [TestMethod]
        public void CreatingFromADirectory()
        {
            ZipFile.CreateFromDirectory(@"C:\temp", @"C:\tempb\JustFiles.zip");
        }

        [TestMethod]
        public void CreatingFromADirectoryWithSubdir()
        {
            ZipFile.CreateFromDirectory(@"C:\temp",
                                        @"C:\tempb\JustFiles.zip",
                                        CompressionLevel.Fastest,
                                        true);
        }

        [TestMethod]
        public void ExtractingAllFiles()
        {
            ZipFile.ExtractToDirectory(@"C:\tempb\JustFiles.zip", @"C:\tempb\unzipped");
        }

        [TestMethod]
        public void AddingExtraFiles()
        {
            ZipFile.CreateFromDirectory(@"C:\temp", @"C:\tempb\AddMoreFiles.zip", CompressionLevel.Fastest, false);

            using (ZipArchive zip = ZipFile.Open(@"c:\tempb\AddMoreFiles.zip",
                                                ZipArchiveMode.Update))
            {
                zip.CreateEntryFromFile(@"C:\temp\subfolder\dummy.txt",
                    "anotherfile.txt");
            }
        }

        [TestMethod]
        public void RemovingFile()
        {
            ZipFile.CreateFromDirectory(@"c:\temp", @"c:\tempb\RemovingFile.zip");

            using (ZipArchive zip = ZipFile.Open(@"c:\tempb\RemovingFile.zip", ZipArchiveMode.Update))
            {
                var f1 = zip.GetEntry("HelloWorld.txt");
                f1.Delete();
            }
        }
    }
}
