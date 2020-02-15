
using System;

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
            bool outOfGuesses = false;

            try
            {
                do
                {
                    Console.Write("Enter guess: ");
                    guess = Console.ReadLine();
                    guessCount++;
                    if (guessCount == guessLimit) outOfGuesses = true;
                } while (guess != secretWord && !outOfGuesses);

                if (guess == secretWord) Console.WriteLine("You Win!");
                else Console.WriteLine("You Lose!");
            }
            catch
            {
                Console.Write("I quit. I quit, I quit, I quit!");
            }
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




static void Main(string[] args)
        {
            try
            {
                do
                {
                    string expression;
                    Console.Clear();
                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter an expression to calculate (e.g. 56 * 8): ");
                        expression = Console.ReadLine();

                    } while (expression.Trim() == "");

                    Console.WriteLine($"{Calculator(expression)}");
                    Console.Write("Type \"exit\" to quit or press Enter to repeat: ");

                } while (Console.ReadLine() != "exit");
            }
            catch
            {
                Console.Write("I quit. I quit, I quit, I quit!");
            }
        }

        static string Calculator (string exp)
        {                                                                                                                       // @"..." - verbatim string, i.e. passed through C# as is to Regex engine
            string validNonExpPattern1          = @"^\s*-?\d+(\.\d+)?\s*$";                                                     // ^ - match has to occur at the beginning of the string
            string validNonExpPattern2          = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";                                           // \s* - 0 or more white-space characters
            string validNonExpPattern3          = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*$";                                        // -? - 0 or 1 occurence of "-"
            string validNonExpPattern4          = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*$";                              // \d+ - 1 or more occurence of digit
            string validNonExpNegativePattern1  = @"^\s*\d+(\.\d+)?\s*\-?\s*$";                                                 // (\.\d+)? - 0 or 1 occurence of "." and 1 or more digits
            string validNonExpNegativePattern2  = @"^\s*\-\d+(\.\d+)?\s*\-?\s*$";                                               // \( - "("
            string validExpPattern1             = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";                        // \) - ")"
            string validExpPattern2             = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";              // [...] - any one of characters
            string validExpPattern3             = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";              // \+ - "+"
            string validExpPattern4             = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";    // \- - "-"
            string validNegativePattern1        = @"^\s*\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";                                 // \* - "*"
            string validNegativePattern2        = @"^\s*\-\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";                               // \/ - "/"
                                                                                                                                // $ - match has to end at the end of the string
            if (Regex.IsMatch(exp, validNonExpPattern1) || Regex.IsMatch(exp, validNonExpPattern2))                             
            {
                if (Regex.IsMatch(exp, validNonExpPattern2)) exp = exp.Replace("(","").Replace(")","");
                return $"\nAnswer is: {Convert.ToDouble(exp)}\n";
            }        
            else if (Regex.IsMatch(exp, validNonExpPattern3) || Regex.IsMatch(exp, validNonExpPattern4))
            {
                if (Regex.IsMatch(exp, validNonExpPattern4)) exp = exp.Replace("(","").Replace(")","");
                if      (Regex.IsMatch(exp, validNonExpNegativePattern1)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'                      )))}\n";
                else if (Regex.IsMatch(exp, validNonExpNegativePattern2)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-', exp.IndexOf('-') + 1)))}\n";
                else return $"\nAnswer is: {Convert.ToDouble(exp.Replace("/","").Replace("*","").Replace("+",""))}\n";
            }
            else if (Regex.IsMatch(exp, validExpPattern1) || Regex.IsMatch(exp, validExpPattern2) || Regex.IsMatch(exp, validExpPattern3) || Regex.IsMatch(exp, validExpPattern4)) 
            { 
                if (Regex.IsMatch(exp, validExpPattern2) || Regex.IsMatch(exp, validExpPattern3) || Regex.IsMatch(exp, validExpPattern4)) exp = exp.Replace("(","").Replace(")","");
                if      (exp.Contains('/')) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('/'))) / Convert.ToDouble(exp.Substring(exp.IndexOf('/') + 1))}\n";
                else if (exp.Contains('*')) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('*'))) * Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}\n";
                else if (exp.Contains('+')) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('+'))) + Convert.ToDouble(exp.Substring(exp.IndexOf('+') + 1))}\n";
                else if (Regex.IsMatch(exp, validNegativePattern1)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'                      ))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-'                      ) + 1))}\n";
                else if (Regex.IsMatch(exp, validNegativePattern2)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-', exp.IndexOf('-') + 1))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-', exp.IndexOf('-') + 1) + 1))}\n";
                else return $"\nThis is unthinkable, you found a bug!\n";
            }
            else return $"\nUnsupported expression format, unable to calculate.\n";
        }

*/
