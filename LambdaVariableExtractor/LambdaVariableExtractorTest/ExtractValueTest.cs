using System;
using LambdaVariableExtractor;
using NUnit.Framework;

namespace LambdaVariableExtractorTest
{
    [TestFixture]
    public class ExtractValueTest
    {
        [Test]
        public void ExtractValue_LambdaWithVariable_Succes()
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
    }
}
