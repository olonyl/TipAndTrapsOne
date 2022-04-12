using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TipAndTrapsOne._01Debugger
{
    [TestClass]
    public class CallerInformationAttribute
    {
        [TestMethod]
        public void ExampleFooMethod()
        {
            var c = new CallerInformationAttributeDemo();

            Trace.WriteLine(c.WhoCalledMe());
            Trace.WriteLine(c.WhatFileCalledMe());
            Trace.WriteLine(c.WhatLineCalledMe());
        }
    }

    internal class CallerInformationAttributeDemo
    {
        public CallerInformationAttributeDemo()
        {
        }

        internal string WhatFileCalledMe([CallerMemberName] string callingMember = null)
        {
            return $"I was called from member {callingMember}";
        }

        internal string WhatLineCalledMe([CallerFilePath] string callingFile = null)
        {
            return $"I was called from file {callingFile}";
        }

        internal string WhoCalledMe([CallerLineNumber] int callingLineNumner = 0)
        {
            return $"I was called from line {callingLineNumner}";
        }
    }

    internal class CallerInformationAttributeDemo2 : INotifyPropertyChanged
    {
        private int _age;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                //Without [CallerMemberName] we have to pass a string of the prop name
                OnPropertyChanged("Age");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                var eventArgs = new PropertyChangedEventArgs(propertyName);

                PropertyChanged(this, eventArgs);
            }
        }
    }
}
