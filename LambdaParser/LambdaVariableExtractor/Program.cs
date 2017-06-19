using System;

namespace LambdaVariableExtractor
{
    class Program
    {
        static void Main()
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
