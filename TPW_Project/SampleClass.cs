using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW_Project
{
    public class SampleClass
    {
        private int _value;

        public SampleClass(int value)
        {
            _value = value;
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
