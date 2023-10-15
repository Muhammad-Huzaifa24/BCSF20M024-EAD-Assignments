using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCalculatorApp
{
    internal class StringSolver
    {
        // check the correctness of infix expression
        public static bool IsInfixExpression(string expression)
        {

            string fullPattern = @"^(\d+(\.\d+)?|[-]?\d+(\.\d+)?|\(\s*[^()]+\s*\))(\s*[+\-*/]\s*(\d+(\.\d+)?|[-]?\d+(\.\d+)?|\(\s*[^()]+\s*\)))*$";

            // Check for unmatched parentheses
            int openParenthesesCount = expression.Count(c => c == '(');
            int closeParenthesesCount = expression.Count(c => c == ')');
            if (openParenthesesCount != closeParenthesesCount)
            {
                return false;
            }
            return Regex.IsMatch(expression, fullPattern);
        }

        // Evaluate the InfixExpression
        public static double Evaluate(string expression)
        {
            char[] tokens = expression.ToCharArray();

            // Stack for numbers: 'values' 
            Stack<double> values = new();

            // Stack for Operators: 'ops' 
            Stack<char> ops = new();

            for (int i = 0; i < tokens.Length; i++)
            {
                // Current token is a whitespace, skip it 
                if (tokens[i] == ' ')
                {
                    continue;
                }

                // Current token is a number, 
                // push it to stack for numbers 
                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sbuf = new();

                    // handle multiple digits number
                    // There may be more than 
                    // one digits in number 
                    // handling decimal expression as well
                    while (i < tokens.Length && (char.IsDigit(tokens[i]) || tokens[i] == '.'))
                    {
                        sbuf.Append(tokens[i++]);
                    }
                    values.Push(double.Parse(sbuf.ToString()));

                    // Right now the i points to 
                    // the character next to the digit,
                    // since the for loop also increases 
                    // the i, we would skip one 
                    //  token position; we need to 
                    // decrease the value of i by 1 to
                    // correct the offset.
                    i--;
                }

                // Current token is an opening
                // brace, push it to 'ops' 
                else if (tokens[i] == '(')
                {
                    ops.Push(tokens[i]);
                }

                // Closing brace encountered,
                // solve entire brace 
                else if (tokens[i] == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }
                    ops.Pop();
                }

                // Current token is an operator. 
                else if (tokens[i] == '+' ||
                         tokens[i] == '-' ||
                         tokens[i] == '*' ||
                         tokens[i] == '/')
                {

                    // While top of 'ops' has same 
                    // or greater precedence to current 
                    // token, which is an operator. 
                    // Apply operator on top of 'ops' 
                    // to top two elements in values stack 
                    while (ops.Count > 0 && HasPrecedence(tokens[i], ops.Peek()))
                    {
                        values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
                    }

                    // Push current token to 'ops'. 
                    ops.Push(tokens[i]);
                }
            }

            // Entire expression has been 
            // parsed at this point, apply remaining 
            // ops to remaining values 
            while (ops.Count > 0)
            {
                values.Push(ApplyOp(ops.Pop(), values.Pop(), values.Pop()));
            }

            // Top of 'values' contains 
            // result, return it 
            return values.Pop();
        }


        // Helper function used in Evalute()
        // to check the precedence
        // of operands and matches them
        public static bool HasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Helper function used in Evaluate()
        // to compute the result of operands
        // based on the given oprator
        public static double ApplyOp(char op, double b, double a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new
                        System.NotSupportedException("Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }
    }
}
