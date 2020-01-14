using System;
using System.Text.RegularExpressions;

namespace Giraffe
{
    class Program
    {
        static void Main(string[] args)
        {
            string guess;
            string secretWord = "giraffe";
            int guessCount = 0;
            int guessLimit = 3;

            do
            {
                Console.Write("Enter guess: ");
                guess = Console.ReadLine();
                guessCount++;

            } while (guess != secretWord && guessCount < guessLimit);

            if (guess == secretWord) Console.WriteLine("You Win!");
            else Console.WriteLine("You Lose!");



            /*
            while (Console.ReadLine() != "exit")
            {
                Console.Write("Enter expression to calculate (e.g. 56 * 8): ");
                Calculator(Console.ReadLine());

            } 
            */

        }

        static void Calculator(string exp)
        {
            string validExpressionPattern = @"^-?\d+(\.\d+)?\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";
            // @"..." - verbatim string, i.e. passed through C# as is to Regex engine
            // ^ - match has to occur at the beginning of the string
            // -? - 0 or 1 occurence of "-"
            // \d+ - 1 or more occurence of digit
            // (\.\d+)? - 0 or 1 occurence of "." and 1 or more digits
            // \s* - 0 or more white-space characters
            // [...] - any one of characters
            // \+ - "+"
            // \- - "-"
            // \* - "*"
            // \/ - "/"
            // $ - match has to end at the end of the string

            if (Regex.IsMatch(exp,validExpressionPattern))
            {
                if      (exp.Contains('/')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('/'))) / Convert.ToDouble(exp.Substring(exp.IndexOf('/') + 1))}");
                else if (exp.Contains('*')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('*'))) * Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}");
                else if (exp.Contains('+')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('+'))) + Convert.ToDouble(exp.Substring(exp.IndexOf('+') + 1))}");
                else if (exp.Contains('-')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-') + 1))}");
                else Console.WriteLine("This is unthinkable, you found a bug!");
            }
            else Console.WriteLine("Unsupported expression format, unable to calculate.");

        }

    }
}

/*

string characterName = "George";
int characterAge = 70;
string phraseCharacter = $"Hello World! My name is {characterName}. I'm {characterAge} years old.";

Console.Write("Hello, please enter your name: ");
string name = Console.ReadLine();

Console.Write("Please enter your age: ");
string age = Console.ReadLine();

string phrase = $"Hello, {name}! You are {age} years old.";
Console.WriteLine(phrase);

Console.Write("Hello, please enter 1st number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Hello, please enter 2nd number: ");
double num2 = Convert.ToDouble(Console.ReadLine());

string result = $"The sum of these two numbers is: {num1 + num2}";
Console.WriteLine(result);

int[] a = { 1, 3, 6, 9 };
string[] b = { "abc", "xyz", "123" };

Console.WriteLine(string.Join(" ", a));
Console.WriteLine(string.Join(" ", b));

Console.WriteLine(phraseCharacter);
Console.WriteLine(5 + 4 * 6);
Console.WriteLine(Math.Abs(-74.5));
Console.WriteLine(Math.Max(65,78));
Console.WriteLine(Math.Round(4.500001));

*/
