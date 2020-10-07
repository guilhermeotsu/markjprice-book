using calculatorLib;
using System;
using Xunit;

namespace CalculatorUnitTests
{
    public class CalculatorUnitTests 
    {
        [Fact]
        public void TestAdding2And2()
        {
            // Arrange
            double a = 2;
            double b = 2;
            double expect = 4;

            // Act
            var calc = new Calculator();

            double result = calc.Add(a, b);

            //Assert 
            Assert.Equal(expect, result);
        }

        [Fact]
        public void TestAdding2And3()
        {
            double a = 2;
            double b = 3;
            double expect = 5;
        
            var calc = new Calculator();
            
            double result = calc.Add(a, b);
        
            Assert.Equal(expect, result);
        }

    }
}