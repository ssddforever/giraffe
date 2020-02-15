
using System;
using System.Text.RegularExpressions;

namespace Giraffe
{
    class Program
    {
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




while (Console.ReadLine() != "exit")
{
    Console.Write("Enter expression to calculate (e.g. 56 * 8): ");
    Calculator(Console.ReadLine());
    Console.Write("Want to calculate again?");

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

            if (Regex.IsMatch(exp, validExpressionPattern))
            {
                if (exp.Contains('/')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('/'))) / Convert.ToDouble(exp.Substring(exp.IndexOf('/') + 1))}");
                else if (exp.Contains('*')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('*'))) * Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}");
                else if (exp.Contains('+')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('+'))) + Convert.ToDouble(exp.Substring(exp.IndexOf('+') + 1))}");
                else if (exp.Contains('-')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-') + 1))}");
                else Console.WriteLine("This is unthinkable, you found a bug!");
            }
            else Console.WriteLine("Unsupported expression format, unable to calculate.");

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

            string validNegation1 = @"^\d+(\.\d+)?\s*\-\s*\d+(\.\d+)?\s*$";
            string validNegation2a = @"^\-\d+(\.\d+)?\s*\-\s*\d+(\.\d+)?\s*$";
            string validNegation2b = @"^\d+(\.\d+)?\s*\-\s*\-\d+(\.\d+)?\s*$";
            string validNegation3 = @"^\-\d+(\.\d+)?\s*\-\s*\-\d+(\.\d+)?\s*$";

            exp.Substring(0, exp.IndexOf('-'));
            Console.WriteLine ()

            if (Regex.IsMatch(exp,validExpressionPattern))
            {
                if (exp.Contains('/')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('/'))) / Convert.ToDouble(exp.Substring(exp.IndexOf('/') + 1))}");
                else if (exp.Contains('*')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('*'))) * Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}");
                else if (exp.Contains('+')) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('+'))) + Convert.ToDouble(exp.Substring(exp.IndexOf('+') + 1))}");
                else if (Regex.IsMatch(exp, validNegation3)) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'))) - Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}");
                else if (Regex.IsMatch(exp, validNegation2a))
                else if (Regex.IsMatch(exp, validNegation2b))
                else if (Regex.IsMatch(exp, validNegation1)) Console.WriteLine($"Answer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-') + 1))}");
                else Console.WriteLine("This is unthinkable, you found a bug!");
            }
            else Console.WriteLine("Unsupported expression format, unable to calculate.");

        }


           static void Calculator(string exp)
        {

            string validExpressionPattern = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";
            // @"..." - verbatim string, i.e. passed through C# as is to Regex engine
            // ^ - match has to occur at the beginning of the string
            // \s* - 0 or more white-space characters
            // -? - 0 or 1 occurence of "-"
            // \d+ - 1 or more occurence of digit
            // (\.\d+)? - 0 or 1 occurence of "." and 1 or more digits
            // [...] - any one of characters
            // \+ - "+"
            // \- - "-"
            // \* - "*"
            // \/ - "/"
            // $ - match has to end at the end of the string

            string validNegationPattern1 = @"^\s*\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";
            string validNegationPattern2 = @"^\s*\-\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";
  
            if (Regex.IsMatch(exp, validExpressionPattern))
            {
                if (exp.Contains('/')) Console.WriteLine($"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('/'))) / Convert.ToDouble(exp.Substring(exp.IndexOf('/') + 1))}\n");
                else if (exp.Contains('*')) Console.WriteLine($"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('*'))) * Convert.ToDouble(exp.Substring(exp.IndexOf('*') + 1))}\n");
                else if (exp.Contains('+')) Console.WriteLine($"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('+'))) + Convert.ToDouble(exp.Substring(exp.IndexOf('+') + 1))}\n");
                else if (Regex.IsMatch(exp, validNegationPattern1)) Console.WriteLine($"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-') + 1))}\n");
                else if (Regex.IsMatch(exp, validNegationPattern2)) Console.WriteLine($"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-', exp.IndexOf('-') + 1))) - Convert.ToDouble(exp.Substring(exp.IndexOf('-', exp.IndexOf('-') + 1) + 1))}\n");
                else Console.WriteLine("\nThis is unthinkable, you found a bug!\n");
            }
            else Console.WriteLine("\nUnsupported expression format, unable to calculate.\n");

        }

    }
}


*/
