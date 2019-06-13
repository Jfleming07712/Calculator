using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Moq;

using Xunit;

namespace Calculator.Test
{
    public class CalculatorInterfaceTests
    {
        [Fact]
        public void Go_AsksForFirstNumberFirst()
        {
            // Arrange
            var screen = new FakeScreen();
            var keypad = new FakeKeypad();
            keypad.Messages = new List<string>
            {
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

        [Fact]
        public void Go_AsksForFirstNumberFirst_UsingMoq()
        {
            // Arrange
            var mockScreen = new Mock<IScreen>();
            var mockKeypad = new Mock<IKeypad>();
            var queue = new Queue<string>(new[] { "5", "*", "2" });
            mockKeypad.Setup(keypad => keypad.GetInput()).Returns(() => queue.Dequeue());

            var calculatorInterface = new CalculatorInterface(mockScreen.Object, mockKeypad.Object);

            // Act
            calculatorInterface.Go();

            // Assert
            mockScreen.Verify(screen => screen.Print("Enter your first number"));
            mockScreen.Verify(screen => screen.Print("Enter the operator"));
            mockScreen.Verify(screen => screen.Print("Enter your Second Number"));
            mockScreen.Verify(screen => screen.Print("Result is 10"));
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

    public class FakeScreen : IScreen
    {
        public List<string> Messages { get; set; } = new List<string>();
        public void Print(string message) {
            this.Messages.Add(message);
        }
    }

    public class FakeKeypad : IKeypad
    {
        private int numMessage = 0;
        public List<string> Messages { get; set; } = new List<string>();

        public string GetInput() {
            return this.Messages[numMessage];
        }
    }
}
