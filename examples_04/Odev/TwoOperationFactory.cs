using System;

namespace Odev
{
    public class OperationFactory
    {
        public static Operation Create(double num1, double num2, char operationSymbol)
        {
            if (operationSymbol == '+')
                return new Addition(num1, num2);
            else if (operationSymbol == '-')
                return new Substract(num1, num2);
            else if (operationSymbol == '*')
                return new Multiple(num1, num2);
            else if (operationSymbol == '/')
                return new Division(num1, num2);

            throw new ArgumentException();
        }

    }
}
