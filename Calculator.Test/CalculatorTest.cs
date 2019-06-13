using System;
using Xunit;
using System.Collections;
using System.Linq;

namespace Calculator.Test
{
    public class Claculator2Tests
    {
        [Fact]
        public void Calculator2_Runs() {
            var calculat = new Calculator(0);
        }
    }

    public class CalculatorTests
    {
        private static Random random = new Random(DateTime.UtcNow.Second);

        [Fact]
        public void CalculaterTestValid()
        {
            // Arrange
            var firstNumber = "5";
            var secondNumber = "2";
            var mathOperator = "*";

            // Act
            var actual = new Calculator(0).Calculate(firstNumber, secondNumber, mathOperator);

            // Assert
            Assert.Equal("Result is 10", actual);
        }

        public string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void Calculate_HandlesRandomeShit()
        {
            // Arrange
            var firstNumber = GetRandomString(38);
            var secondNumber = GetRandomString(38);
            var mathOperator = "*";

            // Act
            var actual = new Calculator(0).Calculate(firstNumber, secondNumber, mathOperator);

            // Assert?
            Assert.Equal("Invalid input", actual);
        }
    }
}
