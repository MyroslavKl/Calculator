using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNew
{
    public class Validator
    {
        public bool ZeroValidator(string? character, string TextBox)
        {
            if (TextBox == String.Empty && character == "0")
            {
                return true;
            }
            return false;
        }
        public bool IsEqualOperator(string? operation, string TextBox)
        {
            if (TextBox != String.Empty && operation=="=")
            {
                return true;
            }
            return false;
        }
        public bool IsPointConsist(StringBuilder buttonText, string character)
        {
            string btnText = buttonText.ToString();
            if (btnText.Contains(',') && character.Contains('.'))
            {
                return true;
            }
            return false;
        }
        public bool IsTimeToSendNumber(string TextBox, string numbers, StringBuilder ButtonText, string operations, string character)
        {
            if (TextBox != String.Empty && character != "." && operations.Contains(character) && numbers.Contains(ButtonText[ButtonText.Length - 1]))
            {
                return true;
            }
            return false;
        }
        public bool IsTimeToSendOperator(string TextBox, string character, string operations, string numbers, StringBuilder ButtonText)
        {
            if (TextBox != String.Empty && numbers.Contains(character) && operations.Contains(ButtonText[0]))
            {
                return true;
            }
            return false;
        }
    }
}
