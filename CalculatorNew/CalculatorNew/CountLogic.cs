using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNew
{
    public class CountLogic
    {
        public static int Priority(char operation)
        {
            switch (operation){
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }
        public static double Calculation(string expression)
        {
            Stack<double> numbers = new Stack<double>();
            Stack<char> operations = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                char character = expression[i];

                if (char.IsDigit(character))
                {
                    string numStr = character.ToString();

                    while (i + 1 < expression.Length && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                    {
                        numStr += expression[i + 1];
                        i++;
                    }

                    if (double.TryParse(numStr, out double number))
                    {
                        numbers.Push(number);
                    }
                }
                else if (character == '+' || character == '-' || character == '*' || character == '/' || character=='^')
                {
                    while (operations.Count > 0 && Priority(operations.Peek()) >= Priority(character))
                    {
                        double rightOperand = numbers.Pop();
                        double leftOperand = numbers.Pop();
                        char operation = operations.Pop();
                        double result = 0;
                        switch (operation)
                        {
                            case '+':
                                result = leftOperand + rightOperand;
                                break;
                            case '-':
                                result = leftOperand - rightOperand;
                                break;
                            case '*':
                                result = leftOperand * rightOperand;
                                break;
                            case '^':
                                result+= 1;
                                for (int j = 0; j < rightOperand; ++j) {
                                    result *= leftOperand;
                                }
                                
                                break;
                            case '/':
                                if (rightOperand != 0)
                                    result = leftOperand / rightOperand;
                                else
                                    MessageBox.Show("Forbidden");
                                break;
                        }
                        numbers.Push(result);
                    }
                    operations.Push(character);
                }
            }

            while (operations.Count > 0)
            {
                double rightOperand = numbers.Pop();
                double leftOperand = numbers.Pop();
                char operation = operations.Pop();
                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = leftOperand + rightOperand;
                        break;
                    case '-':
                        result = leftOperand - rightOperand;
                        break;
                    case '*':
                        result = leftOperand * rightOperand;
                        break;
                    case '^':
                        result = 1;
                        for (int j = 0; j < rightOperand; ++j)
                        {
                            result *= leftOperand;
                        }
                        break;
                    case '/':
                        if (rightOperand != 0)
                            result = leftOperand / rightOperand;
                        else
                            throw new DivideByZeroException("Division by zero is not allowed.");
                        break;
                }

                numbers.Push(result);
            }

            if (numbers.Count == 1)
            {
                return numbers.Pop();
            }
            else
            {
                throw new Exception("Invalid expression format.");
            }
        }
    }
}
