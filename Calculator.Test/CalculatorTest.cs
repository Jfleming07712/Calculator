using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Test
{
    public class CalculatorInterfaceTests
    {
        [Fact]
        public void Go_AsksForFirstNumberFirst() {
            // Arrange
            var screen = new FakeScreen();
            var keypad = new FakeKeypad();
            keypad.Messages = new List<string> {
                "5",
                "2",
                "*",
            };

            var calculatorInterface = new CalculatorInterface(screen, keypad);

            // Act
            calculatorInterface.Go();

            // Assert
            Assert.Equal("Enter your first number", screen.Messages[0]);
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

    public class FakeScreen : CalculatorScreen
    {
        public List<string> Messages { get; set; } = new List<string>();
        public override void Print(string message) {
            this.Messages.Add(message);
        }
    }

    public class FakeKeypad : CalculatorKeypad
    {
        private int numMessage = 0;
        public List<string> Messages { get; set; } = new List<string>();

        public override void GetInput(string message) {
            return this.Messages[numMessage];
        }
    }
}
