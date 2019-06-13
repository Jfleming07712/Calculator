using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        private string InvalidInput = "Invalid input";

        private int howBrokenAmI;

        public Calculator(int brokenness) {
            this.howBrokenAmI = brokenness;
        }

        public string Calculate(string firstNumberString, string secondNumberString, string mathOperator) {
            if (!double.TryParse(firstNumberString, out var firstNumber)) {
                return this.InvalidInput;
            }

            if (!double.TryParse(secondNumberString, out var secondNumber)) {
                return this.InvalidInput;
            }

            secondNumber = secondNumber + this.howBrokenAmI;

            Nullable<double> result;
            switch (mathOperator) {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    result = null;
                    break;
            }

            if (result == null)
            {
                return this.InvalidInput;
            }
            else
            {
                return $"Result is {result}";
            }
        }
    }

    public class CalculatorInterface
    {
        private readonly IScreen screen;
        private readonly IKeypad keypad;

        public CalculatorInterface(IScreen screen, IKeypad keypad) {
            this.screen = screen;
            this.keypad = keypad;
        }

        public void Go() {
            string firstNumber = this.Interact("Enter your first number");
            string mathOperator = this.Interact("Enter the operator");
            string secondNumber = this.Interact("Enter your Second Number");

            var calculator = new Calculator(0);

            var result = calculator.Calculate(firstNumber, secondNumber, mathOperator);
            this.screen.Print(result);
        }

        public string Interact(string message) {
            screen.Print(message);
            screen.Print("> ");

            var response = keypad.GetInput();
            return response;
        }
    }

    public interface IScreen
    {
        void Print(string message);
    }

    public interface IKeypad
    {
        string GetInput();
    }

    public class CalculatorConsole : IScreen, IKeypad
    {
        public string GetInput() {
            return Console.ReadLine();
        }

        public void Print(string message) {
            Console.WriteLine(message);
        }
    }

    public class Program {
        public static void Main(string[] args) {
            var console = new CalculatorConsole();
            new CalculatorInterface(console, console)
                .Go();
        }
    }
}
