using System;


namespace Calculator
{
    public class Calculator
    {

    }

    public class Program
    {

        public static void Main(string[] args)
        {
            string firstNumber = Interact("Enter your first number");
            string mathOperator = Interact("Enter the operator");
            string secondNumber = Interact("Enter your Second Number");

            var result = Calculate(firstNumber, secondNumber, mathOperator);
        }

        public static string Interact(string message) {
            Console.WriteLine(message);
            Console.WriteLine("> ");
            var response = Console.ReadLine();
            return response;
        }

        public static string Calculate(string firstNumberString, string secondNumberString, string mathOperator)
        {
            const string InvalidInput = "Invalid input";

            if (!double.TryParse(firstNumberString, out var firstNumber)) {
                return InvalidInput;
            }

            if (!double.TryParse(secondNumberString, out var secondNumber)) {
                return InvalidInput;
            }

            Nullable<double> result;
            switch (mathOperator)
            {
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
                return InvalidInput;
            }
            else
            {
                return $"Result is {result}";
            }
        }
    }
}
