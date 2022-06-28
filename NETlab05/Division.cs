using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab05
{
    class Division : IOperator
    {
        public string calculate(float left, float right)
        {
            return (left / right).ToString();
        }
    }
}
