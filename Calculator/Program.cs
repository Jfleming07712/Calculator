using System;


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

    public class Program
    {
        public static int Main(string[] args)
        {
            string firstNumber = Interact("Enter your first number");
            string mathOperator = Interact("Enter the operator");
            string secondNumber = Interact("Enter your Second Number");

            var calculator = new Calculator(0);

            var brokenCalculator = new Calculator(5);

            var result1 = calculator.Calculate(firstNumber, secondNumber, mathOperator);
            var result2 = brokenCalculator.Calculate(firstNumber, secondNumber, mathOperator);

            return 0;
        }

        public static string Interact(string message) {
            Console.WriteLine(message);
            Console.WriteLine("> ");
            var response = Console.ReadLine();
            return response;
        }
    }
}
