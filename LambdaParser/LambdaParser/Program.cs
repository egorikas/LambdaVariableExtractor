using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var thisIsClosure = "ThisIsClosure";
            Action actionWithClosure = () =>
            {
                Console.WriteLine(thisIsClosure);
            };

            actionWithClosure();
            Console.WriteLine("! ------------------------- !");

            var thisIsClosureValue = actionWithClosure.ExtractValue<string>("thisIsClosure");
            Console.WriteLine(thisIsClosureValue);

            Console.ReadLine();
        }
    }
}
