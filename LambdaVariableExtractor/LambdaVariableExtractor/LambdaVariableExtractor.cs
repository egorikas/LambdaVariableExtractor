using System;
using System.Linq;
using System.Reflection;

namespace LambdaVariableExtractor
{
    public static class LambdaVariableExtractor
    {
        public static TValue ExtractValue<TValue>(
            this Delegate lambda, string variableName
        )
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
                .SingleOrDefault(x => x.Name == variableName);

            if (field == null)
                throw new NullReferenceException("There isn't a variable with this name");

            if (field.FieldType != typeof(TValue))
                throw new ArgumentException(
                    $"Wrong closure type. Expected - {typeof(TValue).FullName}. Actual - {field.FieldType.FullName}");

            return (TValue) field.GetValue(lambda.Target);
        }
    }
}