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
                if (symbol > 47 && symbol < 58 || symbol == ',')
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
        private List<string> solveBrackets(List<string> expression)
        {
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] == "(")
                {
                    checkBrackets(expression[i]);
                    List<string> bracketExpression = new List<string>();
                    while (bracketBalance != 0)
                    {
                        bracketExpression.Add(expression[i+1]);
                        checkBrackets(expression[i+1]);
                        expression.RemoveAt(i+1);
                    }
                    bracketExpression.RemoveAt(bracketExpression.Count - 1);
                    bracketExpression = solveBrackets(bracketExpression);
                    expression[i] = solve(bracketExpression).ToString();
                }              
            }
            return expression;
        }
        private string solve(List<string> expression)
        {
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] == "*" || expression[i] == "/") 
                {
                    expression[i - 1] = new Operation(expression[i]).useOperator(expression[i - 1], expression[i + 1]);
                    expression.RemoveAt(i + 1); 
                    expression.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] == "+" || expression[i] == "-")
                {
                    expression[i - 1] = new Operation(expression[i]).useOperator(expression[i - 1], expression[i + 1]);
                    expression.RemoveAt(i + 1); 
                    expression.RemoveAt(i);
                    i--;
                }
            }
            return expression.First();
        }
        private void checkBrackets(string element)
        {
            if (element == "(")
                bracketBalance++;
            else if (element == ")")
                bracketBalance--;
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
        public string getSolution()
        {
            return solve(solveBrackets(_expression));
        }
    }
}
