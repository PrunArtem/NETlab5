using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab05
{
    class AlgorithmParse
    {
        private List<string> _expression;
        private int bracketBalance;
        public AlgorithmParse(string rawExpression)
        {
            _expression = new List<string>();
            int expressionPart = 0;
            _expression.Add("");
            foreach (var symbol in rawExpression)
            {
                if (symbol > 47 && symbol < 58)
                    _expression[expressionPart] += symbol;
                else if (symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/')
                {
                    expressionPart++;
                    _expression.Add("");
                    _expression[expressionPart] += symbol;
                    expressionPart++;
                    _expression.Add("");
                }
                else if (symbol == '(')
                {
                    _expression[expressionPart] += symbol;
                    expressionPart++;
                    bracketBalance++;
                    _expression.Add("");
                }
                else if (symbol == ')')
                {
                    expressionPart++;
                    bracketBalance--;
                    _expression.Add("");
                    _expression[expressionPart] += symbol;
                }
            }
            checkErrors();
        }
        private void checkErrors()
        {
            for (int i = 0; i < _expression.Count; i++)
            {
                if (_expression[i] == "")
                    throw new Exception("Expression is not written correctly");
            }
            while (bracketBalance != 0)
            {
                if (bracketBalance < 0)
                {
                    _expression.RemoveAt(_expression.LastIndexOf(")"));
                    bracketBalance++;
                }
                if (bracketBalance > 0)
                {
                    _expression.Remove(_expression.First(x => x == "("));
                    bracketBalance--;
                }
            }
        }
        public string getExpression()
        {
            string expression = "";
            foreach (var expressionPart in _expression)
            {
                expression += expressionPart;
                expression += " ";
            }
            return expression.Trim();
        }
    }
}
