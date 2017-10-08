using System;
using Xunit;

namespace LambdaVariableExtractor.Test
{
    public class ExtractValueTest
    {
        [Fact]
        public void ExtractValue_ActionWithVariable_Success()
        {
            //Arrange
            var closure = "Outside";
            Action actionWithClosure = () =>
            {
                closure = "Inside";
            };

            //Act
            var result = actionWithClosure.ExtractValue<string>("closure");

            //Assert
            Assert.Equal(closure, result);
        }

        [Fact]
        public void ExtractValue_ActionWithTwoVariables_FoundExpected()
        {
            //Arrange
            var firstClosure = "OutsideFirst";
            var secondClosure = "OutsideSecond";

            Action actionWithClosure = () =>
            {
                firstClosure = "InsideFirst";
                secondClosure = "InsideSecond";
                var insideVariable = "SomeValue";
            };

            //Act
            var result = actionWithClosure.ExtractValue<string>("firstClosure");

            //Assert
            Assert.Equal(firstClosure, result);
        }

        [Fact]
        public void ExtractValue_GenericActionWithVariable_Succes()
        {
            //Arrange
            var closure = "Outside";
            Action<string> actionWithClosure = (input) =>
            {
                closure = "Inside";
            };

            //Act
            var result = actionWithClosure.ExtractValue<string>("closure");

            //Assert
            Assert.Equal(closure, result);
        }

        [Fact]
        public void ExtractValue_FuncWithVariable_Succes()
        {
            //Arrange
            var closure = "Outside";
            Func<string> funcWithClosure = () =>
            {
                closure = "Inside";
                return "closure";
            };

            //Act
            var result = funcWithClosure.ExtractValue<string>("closure");

            //Assert
            Assert.Equal(closure, result);
        }

        [Fact]
        public void ExtractValue_NullAction_ExceptionThrown()
        {
            //Arrange
            Action actionWithClosure = null;
            //Act
            var result = Assert.Throws<NullReferenceException>(() => actionWithClosure.ExtractValue<string>("closure"));
            //Assert
            Assert.Equal("Empty lambda", result.Message);
        }

        [Fact]
        public void ExtractValue_ActionWithOutClosure_ExceptionThrown()
        {
            //Arrange
            Action actionWithClosure = () =>
            {
            };

            //Act
            var result = Assert.Throws<NullReferenceException>(() => actionWithClosure.ExtractValue<string>("closure"));

            //Assert
            Assert.Equal("There isn't a variable with this name", result.Message);
        }

        [Fact]
        public void ExtractValue_WrongExpectedType_ExceptionThrown()
        {
            //Arrange
            var closure = "Outside";
            Action actionWithClosure = () =>
            {
                closure = "Inside";
            };

            //Act
            var result = Assert.Throws<ArgumentException>(() => actionWithClosure.ExtractValue<int>("closure"));

            //Assert
            Assert.Equal("Wrong closure type. Expected - System.Int32. Actual - System.String", result.Message);
        }
    }
}
