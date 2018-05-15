using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class ContainException:ApplicationException
    {
        // Реализуем стандартные конструкторы,
        public ContainException() : base() { }
        public ContainException(string str) : base(str) { }
        // Переопределяем метод ToString для класса RangeArrayException.
        public override string ToString()
        {
          return Message;
        }

    }
}
