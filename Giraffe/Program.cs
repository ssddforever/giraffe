
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
        {
            string validNonExpPattern1          = @"^\s*-?\d+(\.\d+)?\s*$";
            string validNonExpPattern2          = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";
            string validNonExpPattern3          = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*$";
            string validNonExpPattern4          = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*$";
            string validNonExpNegativePattern1  = @"^\s*\d+(\.\d+)?\s*\-?\s*$";
            string validNonExpNegativePattern2  = @"^\s*\-\d+(\.\d+)?\s*\-?\s*$";
            string validExpPattern1             = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";
            string validExpPattern2             = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*-?\d+(\.\d+)?\s*$";
            string validExpPattern3             = @"^\s*-?\d+(\.\d+)?\s*[\+\-\*\/]\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";
            string validExpPattern4             = @"^\s*\(\s*-?\d+(\.\d+)?\s*\)\s*[\+\-\*\/]\s*\(\s*-?\d+(\.\d+)?\s*\)\s*$";
            string validNegativePattern1        = @"^\s*\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";
            string validNegativePattern2        = @"^\s*\-\d+(\.\d+)?\s*\-\s*\-?\d+(\.\d+)?\s*$";

            if (Regex.IsMatch(exp, validNonExpPattern1) || Regex.IsMatch(exp, validNonExpPattern2))
            {
                if (Regex.IsMatch(exp, validNonExpPattern2)) exp = exp.Replace("(","").Replace(")","");
                return $"\nAnswer is: {Convert.ToDouble(exp)}\n";
            }        
            else if (Regex.IsMatch(exp, validNonExpPattern3) || Regex.IsMatch(exp, validNonExpPattern4))
            {
                if (Regex.IsMatch(exp, validNonExpPattern4)) exp = exp.Replace("(", "").Replace(")", "");
                if      (Regex.IsMatch(exp, validNonExpNegativePattern1)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-'                      )))}\n";
                else if (Regex.IsMatch(exp, validNonExpNegativePattern2)) return $"\nAnswer is: {Convert.ToDouble(exp.Substring(0, exp.IndexOf('-', exp.IndexOf('-') + 1)))}\n";
                else return $"\nAnswer is: {Convert.ToDouble(exp.Replace("/", "").Replace("*", "").Replace("+", ""))}\n";
            }
            else if (Regex.IsMatch(exp, validExpPattern1) || Regex.IsMatch(exp, validExpPattern2) || Regex.IsMatch(exp, validExpPattern3) || Regex.IsMatch(exp, validExpPattern4)) 
            { 
                if (Regex.IsMatch(exp, validExpPattern2) || Regex.IsMatch(exp, validExpPattern3) || Regex.IsMatch(exp, validExpPattern4)) exp = exp.Replace("(", "").Replace(")", "");
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
