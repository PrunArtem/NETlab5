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
            try
            {
                AlgorithmParse algo = new AlgorithmParse(Console.ReadLine());
                Console.WriteLine(algo.getExpression());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
