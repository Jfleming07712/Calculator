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
            var calculat = new Calculator();
        }
    }

    public class CalculatorTests
    {
        private static Random random = new Random();

        [Fact]
        public void CalculaterTestValid()
        {
            //Arrange
            var firstNumber = "5";
            var secondNumber = "2";
            var mathOperator = "*";

            //Act
            var actual = Program.Calculate(firstNumber, secondNumber, mathOperator);

            //Assert
            Assert.Equal("Result is 10", actual);
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool TryParse(string maybeANumber, out double theNumber) {
            try {
                theNumber = double.Parse(maybeANumber);
            } catch (Exception) {
                theNumber = 0;
                return false;
            }

            return true;
        }

        [Fact]
        public void Calculate_HandlesRandomeShit()
        {
            // Arrange
            var firstNumber = GetRandomString(38);
            var secondNumber = GetRandomString(38);
            var mathOperator = "*";

            // Act
            var actual = Program.Calculate(firstNumber, secondNumber, mathOperator);

            // Assert?
            Assert.Equal("Invalid input", actual);
        }
    }
}
