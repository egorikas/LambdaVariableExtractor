# LambdaVariableExtractor
[![Build status](https://ci.appveyor.com/api/projects/status/9jlgf27ulx2rqv9b/branch/master?svg=true)](https://ci.appveyor.com/project/EgorGrishechko/lambdavariableextractor/branch/master)
[![NuGet](https://img.shields.io/nuget/v/LambdaVariableExtractor.svg)](https://www.nuget.org/packages/LambdaVariableExtractor/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

Simple helper-method for extracting closure values from lambdas.

**[Reason for creating](http://egorikas.com/getting-closure-variable-from-lambda-expression/)**

## Installation

`Install-Package LambdaVariableExtractor`

## Usage

```csharp
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
```

## .NET Standart compatibility
I am going to port this library to .NET Standart 2.0 
