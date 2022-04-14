using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace TipAndTrapsOne._03.Tests
{
    [TestClass]
    public class ExternalProgramExample
    {
        [TestMethod]
        public void SimpleStartByFileExtensionsExample()
        {
            Process.Start(@"c:\temp\HelloWorld.txt");

            const string applicationName = "notepad.exe";
            const string applciationArguments = @"c:\temp\HelloWorld.txt";

            Process.Start(applicationName, applciationArguments);
        }


        [TestMethod]
        public void RedirectingOutputExample()
        {
            var pi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C DATE /T",
                RedirectStandardOutput = true,
                UseShellExecute = false//allows redirection of output
            };

            var p = Process.Start(pi);

            var dateFomCommandLine = p.StandardOutput.ReadToEnd();
        }
    }
}
