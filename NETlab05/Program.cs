using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETlab05
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    AlgorithmParse expression = new AlgorithmParse(Console.ReadLine());
                    Console.WriteLine(expression.getExpression() + " = " + expression.getSolution());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
