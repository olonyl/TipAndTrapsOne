using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class Pathexample
    {
        [TestMethod]
        public void CreatingPathManually()
        {
            var drive = "c:";
            var dir = @"temp\pspathdemo\";
            var file = "test.txt";

            var fullPath = drive;

            if (!drive.EndsWith(@"\"))
            {
                fullPath += @"\";
            }

            fullPath += dir;

            if (!dir.EndsWith(@"\"))
            {
                fullPath += @"\";
            }

            fullPath += file;
        }

        [TestMethod]
        public void UsingPathCombine()
        {
            var drive = "c:";
            var dir = @"temp\pspathdemo\";
            var file = "test.txt";

            var fullPath = System.IO.Path.Combine(drive, dir, file);

            drive = @"c:\";

            fullPath = System.IO.Path.Combine(drive, dir, file);
        }

        [TestMethod]
        public void PathCombinePeculiarities()
        {
            var result = System.IO.Path.Combine(@"\data", @"c:\temp");

            result = System.IO.Path.Combine(@"c:\temp", @"\data");

            result = System.IO.Path.Combine(@"c:\temp", @"data");

            result = System.IO.Path.Combine(@"c:\temp", @"\data".Trim(Path.DirectorySeparatorChar));

            result = Path.Combine("", @"c:\data");
            result = Path.Combine(@"x:\data", "");

            result = Path.Combine(@"c:\temp\data", @"..");

            result = Path.GetFullPath(result);
        }

        [TestMethod]
        public void UsefulPathMethods()
        {
            var path = @"c:\temp\pspathdemo\test.txt";

            path = Path.ChangeExtension(path, "bak");

            var dirName = Path.GetDirectoryName(path);

            var ext = Path.GetExtension(path);

            var file = Path.GetFileName(path);

            var fileNoExt = Path.GetFileNameWithoutExtension(path);

            bool hasExt = Path.HasExtension(path);
        }

        [TestMethod]
        public void UsefulGeneralMethods()
        {
            var invalidNameChars = Path.GetInvalidFileNameChars();

            var rndFileName = Path.GetRandomFileName();

            var rndTempFile = Path.GetTempFileName();

            var userTempPath = Path.GetTempPath();

            char platformSpecificDirSeparater = Path.DirectorySeparatorChar;
        }
    }
}
