using System;
using LambdaVariableExtractor;
using NUnit.Framework;

namespace LambdaVariableExtractorTest
{
    [TestFixture]
    public class ExtractValueTest
    {
        [Test]
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
            Assert.That(result, Is.EqualTo(closure));
        }

        [Test]
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
            Assert.That(result, Is.EqualTo(firstClosure));
        }

        [Test]
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
            Assert.That(result, Is.EqualTo(closure));
        }

        [Test]
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
            Assert.That(result, Is.EqualTo(closure));
        }

        [Test]
        public void ExtractValue_NullAction_ExceptionThrown()
        {
            //Arrange
            Action actionWithClosure = null;
            //Act
            var result = Assert.Throws<NullReferenceException>(() => actionWithClosure.ExtractValue<string>("closure"));
            //Assert
            Assert.That(result.Message, Is.EqualTo("Empty lambda"));
        }

        [Test]
        public void ExtractValue_ActionWithOutClosure_ExceptionThrown()
        {
            //Arrange
            Action actionWithClosure = () =>
            {
            };

            //Act
            var result = Assert.Throws<NullReferenceException>(() => actionWithClosure.ExtractValue<string>("closure"));

            //Assert
            Assert.That(result.Message, Is.EqualTo("There isn't a variable with this name"));
        }

        [Test]
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
            Assert.That(result.Message, Is.EqualTo("Wrong closure type. Expected - System.Int32. Actual - System.String"));
        }
    }
}
