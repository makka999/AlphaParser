using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class RecursiveDescentParser
    {
        private readonly string _input;
        private int _position;

        public RecursiveDescentParser(string input)
        {
            _input = input;
            _position = 0;
        }

        public int Parse()
        {
            int result = Expression();
            if (_position != _input.Length)
                throw new Exception("Unexpected characters at the end of expression.");
            return result;
        }

        private int Expression()
        {
            int value = Term();
            while (Current == '+' || Current == '-')
            {
                char op = Current;
                Next();
                int term = Term();
                value = op == '+' ? value + term : value - term;
            }
            return value;
        }

        private int Term()
        {
            int value = Factor();
            while (Current == '*' || Current == '/')
            {
                char op = Current;
                Next();
                int factor = Factor();
                if (op == '*')
                    value *= factor;
                else
                {
                    if (factor == 0)
                        throw new Exception("Division by zero.");
                    value /= factor;
                }
            }
            return value;
        }

        private int Factor()
        {
            if (Current == '(')
            {
                Next();
                int value = Expression();
                Expect(')');
                return value;
            }
            return Number();
        }

        private int Number()
        {
            int start = _position;
            while (char.IsDigit(Current))
                Next();

            string number = _input.Substring(start, _position - start);
            if (!int.TryParse(number, out int value))
                throw new Exception("Invalid number format.");

            return value;
        }

        private void Expect(char expected)
        {
            if (Current != expected)
                throw new Exception($"Expected '{expected}' but found '{Current}'.");
            Next();
        }

        private void Next()
        {
            _position++;
        }

        private char Current => _position < _input.Length ? _input[_position] : '\0';
    }
}
