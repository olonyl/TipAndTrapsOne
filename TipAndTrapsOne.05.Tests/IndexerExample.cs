using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TipAndTrapsOne._05.Tests
{
    [TestClass]
    public class IndexerExample
    {
        [TestMethod]
        public void ExampleUseInFramework()
        {
            var names = new List<string>
            {
                "Sarah",
                "Gentry"
            };

            var gentry = names[1];
        }

        [TestMethod]
        public void UsingAnIndexer()
        {
            var bigFile = new DemoFileArray(@"c:\temp\largefile.bin");

            //get a byte value using the indexer
            byte valueAtOffset = bigFile[999999];

            valueAtOffset++; //assumes value will not exceed byte.MaxValue

            // set a byte value using the indexer
            bigFile[9999999] = valueAtOffset;
        }

        [TestMethod]
        public void BadExample()
        {
            var sarah = new Student();

            var secondExamScore = sarah[1];
        }
    }

    internal class Student
    {
        private int[] _examScores = { 56, 22, 99, 25 };

        public int this[int index]
        {
            get { return _examScores[index]; }
            set { _examScores[index] = value; }
        }
    }

    internal class DemoFileArray
    {
        private string _filePath;

        public DemoFileArray(string filePath)
        {
            _filePath = filePath;
        }
        public byte this[long index]
        {
            get
            {
                return 42;
            }
            set
            {
                byte valueToWriteFile = value;
            }
        }

    }
}
