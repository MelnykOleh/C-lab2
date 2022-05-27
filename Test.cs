using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csharp
{
    class Test
    {
        private string _name;
        private bool _passed;

        public Test(string name, bool isPassed)
        {
            Name = name;
            Passed = isPassed;
        }

        public Test() : this(name: "test1", isPassed: true) { }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public bool Passed
        {
            get
            {
                return _passed;
            }
            set
            {
                _passed = value;
            }
        }

        public override string ToString()
        {
            return $"\nName:{Name}\nIsPassed:{Passed}\n";
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Passed.GetHashCode() ;
        }
    }
}
