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
        public Operation(string Operatorr)
        {

            switch (Operatorr)
            {
                case "*":
                    _operator = new Multiplication();
                    break;
                case "/":
                    _operator = new Division();
                    break;
                case "+":
                    _operator = new Addition();
                    break;
                case "-":
                    _operator = new Subtraction();
                    break;
            };
        }
        public void SetStrategy(IOperator Operatorr)
        {
            _operator = Operatorr;
        }
        public string useOperator(string left, string right)
        {
            float floatLeft = float.Parse(left);
            float floatRight = float.Parse(right);
            return _operator.calculate(floatLeft, floatRight);

        }
    }
}
