using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Simple Console Calculator!");

        bool continueCalculation = true;

        while (continueCalculation)
        {
            // Display options to the user
            Console.WriteLine("\nAvailable operations:");
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Exit");

            // Ask for user's choice
            Console.Write("\nEnter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformOperation("+");
                    break;
                case "2":
                    PerformOperation("-");
                    break;
                case "3":
                    PerformOperation("*");
                    break;
                case "4":
                    PerformOperation("/");
                    break;
                case "5":
                    continueCalculation = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Simple Console Calculator!");

    }

    static void PerformOperation(string operation)
    {
        Console.Write($"Enter the first number for {operation}: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Enter the second number for {operation}: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                Console.WriteLine($"Result of {num1} + {num2} = {result}");
                break;
            case "-":
                result = num1 - num2;
                Console.WriteLine($"Result of {num1} - {num2} = {result}");
                break;
            case "*":
                result = num1 * num2;
                Console.WriteLine($"Result of {num1} * {num2} = {result}");
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                    Console.WriteLine($"Result of {num1} / {num2} = {result}");
                }
                else
                {
                    Console.WriteLine("Division by zero is not allowed.");
                }
                break;
            default:
                break;
        }
    }
}