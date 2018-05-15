using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class EmptyException : ApplicationException
    {
        // Реализуем стандартные конструкторы,
        public EmptyException() : base() { }
        public EmptyException(string str) : base(str) { }
        // Переопределяем метод ToString для класса RangeArrayException.
        public override string ToString()
        {
            return Message;
        }

    }
}
