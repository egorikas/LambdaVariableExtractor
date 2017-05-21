using System;
using System.Linq;
using System.Reflection;

namespace LambdaParser
{
    public static class LambdaVariableExtractor
    {
        public static TValue ExtractValue<TValue>(this Delegate lambda, string variableName)
            where TValue : class
        {
            if (lambda == null)
                throw new NullReferenceException("Empty lambda");

            var field = lambda.Method.DeclaringType?.GetFields
                (
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.Static
                )
                .Single(x => x.Name == name);

            if (field == null)
                throw new NullReferenceException("There isn't a variable with this name");


            return field.GetValue(lambda.Target) as TValue;
        }
    }
}