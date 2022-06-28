using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab05
{
    class Operation
    {
        private IOperator _operator;
        public Operation(IOperator Operatorr)
        {
            _operator = Operatorr;
        }
        public void SetStrategy(IOperator Operatorr)
        {
            _operator = Operatorr;
        }
        public float useOperator(string left, string right)
        {
            float floatLeft = float.Parse(left);
            float floatRight = float.Parse(right);
            return _operator.calculate(floatLeft, floatRight);

        }
    }
}
