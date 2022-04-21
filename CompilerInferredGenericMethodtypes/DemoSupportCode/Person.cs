using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CompilerInferredGenericMethodtypes.DemoSupportCode
{
    [DebuggerTypeProxy(typeof(PersonDebugProxy))]
    class Person
    {
        private readonly string _name;

        public Person(string name)
        {
            _name = name;
            FavouriteColors = new SortedList<int, string>();

        }

        public int Age { get; set; }
        public SortedList<int, string> FavouriteColors { get; set; }
        private class PersonDebugProxy
        {
            private readonly Person _objectToProxy;
            public PersonDebugProxy(Person objectToProxy)
            {
                _objectToProxy = objectToProxy;
            }
            public string PersonalDetails
            {
                get
                {
                    return string.Format("{0},{1} years old", _objectToProxy._name,
                        _objectToProxy.Age);
                }
            }

            public string MostFavouriteColor
            {
                get
                {
                    if (_objectToProxy.FavouriteColors.Any())
                    {
                        return _objectToProxy.FavouriteColors.First().Value;
                    }
                    return "No favourite colors";
                }
            }
        }

    }


}
