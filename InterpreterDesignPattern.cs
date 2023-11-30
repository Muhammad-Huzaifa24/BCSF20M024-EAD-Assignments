using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // Abstract expression
    interface IExpression
    {
        int Interpret(Dictionary<string, int> context);
    }

    // Terminal expression
    class NumberExpression : IExpression
    {
        private readonly string variableName;

        public NumberExpression(string variableName)
        {
            this.variableName = variableName;
        }

        public int Interpret(Dictionary<string, int> context)
        {
            return context[variableName];
        }
    }

    // Non-terminal expression
    class AdditionExpression : IExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public AdditionExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret(Dictionary<string, int> context)
        {
            return left.Interpret(context) + right.Interpret(context);
        }
    }

    // ****************************************  Example 02 *******************************************

    // Abstract expression
    interface IBooleanExpression
    {
        bool Interpret(Dictionary<string, bool> context);
    }

    // Terminal expression
    class VariableExpression : IBooleanExpression
    {
        private readonly string variableName;

        public VariableExpression(string variableName)
        {
            this.variableName = variableName;
        }

        public bool Interpret(Dictionary<string, bool> context)
        {
            return context[variableName];
        }
    }

    // Non-terminal expression
    class AndExpression : IBooleanExpression
    {
        private readonly IBooleanExpression left;
        private readonly IBooleanExpression right;

        public AndExpression(IBooleanExpression left, IBooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public bool Interpret(Dictionary<string, bool> context)
        {
            return left.Interpret(context) && right.Interpret(context);
        }
    }
}
